using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

namespace SophosPartnerCentral
{
    public partial class HauptFenster : Form
    {
        public HauptFenster()
        {
            InitializeComponent();
            this.Text = "Sophos Partner Central - V" + Application.ProductVersion;
            ResetView();
            Start();
        }

        public void ResetView()
        {
            ListBoxKunden.Items.Clear();
            ListViewDevices.Items.Clear();
            LabelBillingType.Text = "";
            LabelDataGeography.Text = "";
            LabelSonstiges.Text = "";
            LabelKundenName.Text = "Kein Kunde ausgewählt.";
            ToolStripLabelPartnerName.Text = "---";
        }

        Token AccessToken;
        Whoami PartnerAccount;
        List<TenantItem> PartnerTenants;
        List<EndpointItem> SelectedTenantEndpoints;
        public async void Start()
        {
            ResetView();
            Ladebalken.Visible = true;
            AccessToken = await GetSophosAccessToken();
            PartnerAccount = await GetSophosWhoami(AccessToken);
            PartnerTenants = (await GetSophosPartnerTenants(AccessToken, PartnerAccount.id)).OrderBy(x => x.name).ToList();

            ToolStripLabelPartnerName.Text = "Partner-ID: " + PartnerAccount.id;

            ListBoxKunden.Items.Clear();
            foreach (TenantItem einTenant in PartnerTenants)
            {
                if(toolStripMenuItemZKunden.Checked == true)
                {
                    if (einTenant.name.StartsWith("Z - ") || einTenant.name.StartsWith("ZZZ - "))
                    {
                        
                    } else
                    {
                        ListBoxKunden.Items.Add(einTenant.name);
                    }
                } else
                {
                    ListBoxKunden.Items.Add(einTenant.name);
                }
            }

            Ladebalken.Visible = false;
        }

        private static async Task<TamperProtection> GetSophosEndpointTamperProtection(Token AccessToken, String EndpointID, String TenantID, String TenanantURI)
        {
            try { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(TenanantURI);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken.AccessToken);
                    client.DefaultRequestHeaders.Add("X-Tenant-ID", TenantID);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("endpoint/v1/endpoints/" + EndpointID + "/tamper-protection").Result;
                    response.EnsureSuccessStatusCode();
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    TamperProtection EndpointTamperProtection = JsonConvert.DeserializeObject<TamperProtection>(jsonContent);
                    return EndpointTamperProtection;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler beim Abruf des Manipulationsschutzes: \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TamperProtection();
            }
        }

        private static async Task<List<EndpointItem>> GetSophosTenantEndpoints(Token AccessToken, String TenantID, String TenantURI)
        {
            try { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(TenantURI);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken.AccessToken);
                    client.DefaultRequestHeaders.Add("X-Tenant-ID", TenantID);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    List<Endpoint> TenantEndpoints = new List<Endpoint>();
                    var response = client.GetAsync("endpoint/v1/endpoints?pageTotal=True").Result;
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    } catch (Exception e) { MessageBox.Show("Kein Zugriff auf diesen Kunden \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); return new List<EndpointItem>(); }
                    var jsonContent = await response.Content.ReadAsStringAsync();

                    TenantEndpoints.Add(JsonConvert.DeserializeObject<Endpoint>(jsonContent));

                    int i = 1;
                    while (i < TenantEndpoints[0].pages.total)
                    {
                        response = client.GetAsync("endpoint/v1/endpoints?pageTotal=True&pageFromKey=" + TenantEndpoints[i - 1].pages.nextKey).Result;
                        response.EnsureSuccessStatusCode();
                        jsonContent = await response.Content.ReadAsStringAsync();
                        TenantEndpoints.Add(JsonConvert.DeserializeObject<Endpoint>(jsonContent));
                        i++;
                    }

                    List<EndpointItem> EndpointList = new List<EndpointItem>();
                    foreach (Endpoint endpointPage in TenantEndpoints)
                    {
                        foreach (EndpointItem einEndpoint in endpointPage.items)
                        {
                            EndpointList.Add(einEndpoint);
                        }
                    }

                    return EndpointList;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler beim Abruf der Endpoints: \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<EndpointItem>();
            }
        }

        private static async Task<List<TenantItem>> GetSophosPartnerTenants(Token AccessToken, String PartnerID)
        {
            try { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.central.sophos.com");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken.AccessToken);
                    client.DefaultRequestHeaders.Add("X-Partner-ID", PartnerID);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    List<Tenant> PartnerTenants = new List<Tenant>();
                    var response = client.GetAsync("partner/v1/tenants?pageTotal=True").Result;
                    response.EnsureSuccessStatusCode();
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    PartnerTenants.Add(JsonConvert.DeserializeObject<Tenant>(jsonContent));

                    int i = 1;
                    while(i < PartnerTenants[0].pages.total)
                    {
                        response = client.GetAsync("partner/v1/tenants?pageTotal=True&page=" + (i + 1)).Result;
                        response.EnsureSuccessStatusCode();
                        jsonContent = await response.Content.ReadAsStringAsync();
                        PartnerTenants.Add(JsonConvert.DeserializeObject<Tenant>(jsonContent));
                        i++;
                    }

                    List<TenantItem> TenantList = new List<TenantItem>();
                    foreach(Tenant tenantPage in PartnerTenants)
                    {
                        foreach (TenantItem einTenant in tenantPage.items)
                        {
                            TenantList.Add(einTenant);
                        }
                    } 

                    return TenantList;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler beim Abruf der Kunden-/Accountliste: \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<TenantItem>();
            }

        }

        private static async Task<Whoami> GetSophosWhoami(Token AccessToken)
        {
            try { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.central.sophos.com");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken.AccessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("whoami/v1").Result;
                    response.EnsureSuccessStatusCode();
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    Whoami PartnerAccount = JsonConvert.DeserializeObject<Whoami>(jsonContent);
                    return PartnerAccount;
                }
            } catch (Exception e)
            {
                MessageBox.Show("Fehler beim WhoAmI-Abruf (Partner): \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Whoami();
            }  
        }
        private static async Task<Token> GetSophosAccessToken()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string baseAddress = @"https://id.sophos.com/api/v2/oauth2/token";

                    string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string configINIFile = BasePath + @"\config.ini";

                    if(!File.Exists(configINIFile))
                    {
                        MessageBox.Show("Die config.ini kann nicht geladen werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }

                    INIFile inif = new INIFile(configINIFile);
 
                    var Content = new Dictionary<string, string>
                    {
                        {"grant_type", "client_credentials"},
                        {"client_id", inif.Read("CentralAPI", "ID")},
                        {"client_secret", inif.Read("CentralAPI", "Secret")},
                        {"scope", "token"}
                    };

                    HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(Content));
                    var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
                    Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                    return tok;
                }
            } catch (Exception e)
            {
                MessageBox.Show("Fehler beim Abruf des AccessToken: \n" + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Token();
            }
        }

        private void AktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private async void ListBoxKunden_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ladebalken.Visible = true;

            TenantItem selectedTenant = PartnerTenants[ListBoxKunden.SelectedIndex];
            LabelKundenName.Text = selectedTenant.name;
            switch(selectedTenant.billingType)
            {
                case "term":
                    LabelBillingType.Text = "Regulär / Volllizenierung";
                    break;
                case "trial":
                    LabelBillingType.Text = "Trial / Testversion";
                    break;
                case "usage":
                    LabelBillingType.Text = "MSP / Nutzungsbasiert";
                    break;
                default:
                    LabelBillingType.Text = "Unbekannt";
                    break;

            }
            LabelDataGeography.Text = selectedTenant.dataGeography;
            LabelSonstiges.Text = selectedTenant.id;

            SelectedTenantEndpoints = (await GetSophosTenantEndpoints(AccessToken, selectedTenant.id, selectedTenant.apiHost)).OrderBy(x => x.hostname).ToList();

            ListViewDevices.Items.Clear();

            foreach (EndpointItem einEndpoint in SelectedTenantEndpoints)
            {
                ListViewItem neuerEintrag = ListViewDevices.Items.Add(new ListViewItem(new String[] { "[blank]", einEndpoint.type, (einEndpoint.health == null ? "" : einEndpoint.health.overall), (einEndpoint.associatedPerson == null ? "" : einEndpoint.associatedPerson.viaLogin), einEndpoint.lastSeenAt, einEndpoint.os.name, (einEndpoint.tamperProtectionEnabled == true ? "Aktiv" : "Inaktiv"), einEndpoint.ipv4Addresses[0], (einEndpoint.health == null ? "" : einEndpoint.health.threats.status), (einEndpoint.health == null ? "" : einEndpoint.health.services.status) }));
                neuerEintrag.Text = einEndpoint.hostname;
                neuerEintrag.Tag = einEndpoint.id;
                if (einEndpoint.health != null)
                {
                    switch (einEndpoint.health.overall)
                    {
                        default:
                            break;
                        case "bad":
                            neuerEintrag.ForeColor = Color.Red;
                            break;
                        case "suspicious":
                            neuerEintrag.ForeColor = Color.Orange;
                            break;
                    }
                } else
                {
                    neuerEintrag.ForeColor = Color.Red;
                }
            }

            Ladebalken.Visible = false;
        }

        private async void MapulationsschutzkennwortAbrufenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TamperProtection selectedEndpointTamperProtection = await GetSophosEndpointTamperProtection(AccessToken, ListViewDevices.SelectedItems[0].Tag.ToString(), PartnerTenants[ListBoxKunden.SelectedIndex].id, PartnerTenants[ListBoxKunden.SelectedIndex].apiHost);
            Clipboard.SetText(selectedEndpointTamperProtection.password);
            MessageBox.Show("Manipulationsschutzkennwort: " + selectedEndpointTamperProtection.password + "\n\n(In Zwischenablage kopiert)");
        }


        private void ListViewDevices_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //ItemComparer sorter = ListViewDevices.ListViewItemSorter as ItemComparer;
            //if (sorter == null)
            //{
            //    sorter = new ItemComparer(e.Column);
            //    ListViewDevices.ListViewItemSorter = sorter;
            //}
            //else
            //{
            //    sorter.Column = e.Column;
            //}
            //ListViewDevices.Sort();
        }

        private async void ListViewDevices_DoubleClick(object sender, EventArgs e)
        {
            TamperProtection selectedEndpointTamperProtection = await GetSophosEndpointTamperProtection(AccessToken, ListViewDevices.SelectedItems[0].Tag.ToString(), PartnerTenants[ListBoxKunden.SelectedIndex].id, PartnerTenants[ListBoxKunden.SelectedIndex].apiHost);
            EndpointFenster EndpointDetail = new EndpointFenster();
            EndpointDetail.LabelHostname.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].hostname;
            EndpointDetail.LabelKundenName.Text = PartnerTenants[ListBoxKunden.SelectedIndex].name;
            EndpointDetail.LabelEndpointType.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].type;
            if (SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].health != null)
            {
                EndpointDetail.LabelGesamtStatus.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].health.overall;
                EndpointDetail.LabelDienstStatus.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].health.services.status;
                EndpointDetail.LabelBedrohungsStatus.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].health.threats.status;
            }
            if (SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].associatedPerson != null)
            {
                EndpointDetail.LabelBenutzerLogin.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].associatedPerson.viaLogin;
                EndpointDetail.LabelBenutzerName.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].associatedPerson.name;
            }
            EndpointDetail.LabelOSPlatform.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].os.platform;
            EndpointDetail.LabelOSName.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].os.name;
            EndpointDetail.LabelOSBuild.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].os.build.ToString();
            EndpointDetail.LabelIPv4Address.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].ipv4Addresses[0];
            if (SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].ipv6Addresses != null)
            {
                EndpointDetail.LabelIPv6Address.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].ipv6Addresses[0];
            }
            EndpointDetail.LabelTamperProtectionStatus.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].tamperProtectionEnabled.ToString();
            EndpointDetail.LabelTamperProtectionPassword.Text = selectedEndpointTamperProtection.password;
            EndpointDetail.LabelLastSeen.Text = SelectedTenantEndpoints[ListViewDevices.SelectedItems[0].Index].lastSeenAt;
            EndpointDetail.ShowDialog();
        }
        private void ToolStripMenuItemZKunden_CheckedChanged_1(object sender, EventArgs e)
        {
            Start();
        }
    }


    public class ItemComparer : IComparer<object>
    {
        //column used for comparison
        public int Column { get; set; }
        public ItemComparer(int colIndex)
        {
            Column = colIndex;
        }
        public int Compare(object a, object b)
        {
            int result;
            ListViewItem itemA = a as ListViewItem;
            ListViewItem itemB = b as ListViewItem;
            if (itemA == null && itemB == null)
                result = 0;
            else if (itemA == null)
                result = -1;
            else if (itemB == null)
                result = 1;
            if (itemA == itemB)
                result = 0;
            //alphabetic comparison
            result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            return result;
        }
    }



    internal class Whoami
    {
        public string id { get; set; }
        public string idType { get; set; }
        public WhoamiApiHosts apiHosts { get; set; }
    }
    internal class TamperProtection
    {
        public bool enabled { get; set; }
        public string password { get; set; }
        public TamperProtectionPreviousPasswords[] previousPasswords { get; set; }
    }
    internal class TamperProtectionPreviousPasswords
    {
        public string invalidatedAt { get; set; }
        public string password { get; set; }
    }
    internal class Endpoint
    {
        public EndpointItem[] items { get; set; }
        public EndpointPages pages { get; set; }
    }
    internal class EndpointItem
    {
        public EndpointItemAssignedProduct[] assignedProducts { get; set; }
        public EndpointItemAssignedPerson associatedPerson { get; set; }
        public EndpointItemEncryption encryption { get; set; }
        public EndpointItemHealth health { get; set; }
        public string hostname { get; set; }
        public string id { get; set; }
        public string[] ipv4Addresses { get; set; }
        public string[] ipv6Addresses { get; set; }
        public string lastSeenAt { get; set; }
        public EndpointItemLockdown lockdown { get; set; }
        public string[] macAddresses { get; set; }
        public EndpointItemOS os { get; set; }
        public bool tamperProtectionEnabled { get; set; }
        public EndpointItemTenant tenant { get; set; }
        public string type { get; set; }
    }
    internal class EndpointItemAssignedProduct
    {
        public string code { get; set; }
        public string version { get; set; }

    }
    internal class EndpointItemAssignedPerson
    {
        public string name { get; set; }
        public string viaLogin { get; set; }
    }
    internal class EndpointItemEncryption
    {
        public EndpointItemEncryptionVolume[] volumes { get; set; }
    }
    internal class EndpointItemEncryptionVolume
    {
        public string status { get; set; }
        public string volumeId { get; set; }
    }
    internal class EndpointItemHealth
    {
        public string overall { get; set; }
        public EndpointItemHealthServices services { get; set; }
        public EndpointItemHealthThreats threats { get; set; }
    }
    internal class EndpointItemHealthServices
    {
        public EndpointItemHealthServicesServiceDetail[] serviceDetails { get; set; }
        public string status { get; set; }
    }
    internal class EndpointItemHealthServicesServiceDetail
    {
        public string name { get; set; }
        public string status { get; set; }
    }
    internal class EndpointItemHealthThreats
    {
        public string status { get; set; }
    }
    internal class EndpointItemLockdown
    {
        public string status { get; set; }
        public string updateStatus { get; set; }
    }
    internal class EndpointItemOS
    {
        public int build { get; set; }
        public bool isServer { get; set; }
        public int majorVersion { get; set; }
        public int minorVersion { get; set; }
        public string name { get; set; }
        public string platform { get; set; }
    }
    internal class EndpointItemTenant
    {
        public string id { get; set; }
    }
    internal class EndpointPages
    {
        public string fromKey { get; set; }
        public int maxSize { get; set; }
        public string nextKey { get; set; }
        public int size { get; set; }
        public int total { get; set; }
    }


    internal class Tenant
    {
        public TenantItem[] items { get; set; }
        public TenantPages pages { get; set; }
    }
    internal class TenantItem
    {
        public string apiHost { get; set; }
        public string billingType { get; set; }
        public string dataGeography { get; set; }
        public string dataRegion { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public TenantOrganisation organization { get; set; }
        public TenantPartner partner { get; set; }
    }
    internal class TenantOrganisation
    {
        public string id { get; set; }
    }
    internal class TenantPartner
    {
        public string id { get; set; }
    }
    internal class TenantPages
    {
        public int current { get; set; }
        public int maxSize { get; set; }
        public int size { get; set; }
        public int total { get; set; }
    }

    internal class WhoamiApiHosts
    {
        public string dataRegion { get; set; }
        public string global { get; set; }
    }

    internal class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }


    class INIFile
    {
        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        public INIFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
        }

        public string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
            return SB.ToString();
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
    }


}
