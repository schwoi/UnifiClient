using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using UnifiApi;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApiTests.Models;
using Xunit;

namespace UnifiApiTests
{
    public class ClientTests
    {
        private readonly string _url ;
        private readonly string _user;
        private readonly string _pass ;

        public ClientTests()
        {
            var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(@"settings.json"));
            _url = settings.Url;
            _user = settings.User;
            _pass = settings.Pass;
        }
        
        [Fact]
        public async Task CanAuthenticate()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var result = await unifiClient.LoginAsync(_user, _pass);
                result.Result.ShouldBeTrue();
                unifiClient.IsLoggedIn.ShouldBeTrue();
            }
        }

        [Fact(Skip = "Fail's on default demo site")]
        public async Task ShouldFailToAuthenticate()
        {
            using (var unifiClient = new Client(_url))
            {
                var result = await unifiClient.LoginAsync(_user, "");
                result.Result.ShouldBeFalse();
            }
        }

        [Fact]
        public async Task CanLogout()
        {
            var unifiClient = new Client(_url);
            await unifiClient.LoginAsync(_user, _pass);
            unifiClient.IsLoggedIn.ShouldBeTrue();

            await unifiClient.LogoutAsync();
            unifiClient.IsLoggedIn.ShouldBeFalse();
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldGetControllerStatus()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.GetControllerStatusAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Meta.Up.ShouldBe(true);
                result.Meta.Uuid.ShouldNotBe(Guid.Empty);
            }
        }
        [Fact]
        public async Task ShouldGeCountryCodeList()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListCountryCodesAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count().ShouldBeGreaterThan(0);
            }
        }
        [Fact]
        public async Task ShouldGetListOfSites()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListSitesAsync();

                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldCreateSite()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.CreateSiteAsync("TestSite");
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
                result.Data.First().Description.ShouldBe("TestSite");

                await unifiClient.DeleteSiteAsync(result.Data.First().Id);
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldUpdateSite()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateSiteAsync("UpdateSite");
                createResult.ShouldNotBeNull();
                createResult.Meta.Rc.ToLower().ShouldBe("ok");
                createResult.Data.Count.ShouldBeGreaterThan(0);

                var result = await unifiClient.RenameSiteAsync("UpdatedSite", createResult.Data.First().Name);
                result.Result.ShouldBe(true);

                await unifiClient.DeleteSiteAsync(createResult.Data.First().Id);
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldUpdateSiteCountry()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateSiteAsync("CountrySite");
                createResult.ShouldNotBeNull();
                createResult.Meta.Rc.ToLower().ShouldBe("ok");

                var countries = await unifiClient.ListCountryCodesAsync();
                var aust = countries.Data.FirstOrDefault(x => x.Name.Equals("Australia"));
                var country = new CountrySetting
                {
                    Code = aust.Code,
                    SiteId = createResult.Data.First().Id
                };
                
                var result = await unifiClient.SetSiteCountryAsync(country, createResult.Data.First().Name);
                result.Result.ShouldBe(true);

                await unifiClient.DeleteSiteAsync(createResult.Data.First().Id);
            }
        }
        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldUpdateSiteLocale()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateSiteAsync("LocaleSite");
                createResult.ShouldNotBeNull();
                createResult.Meta.Rc.ToLower().ShouldBe("ok");

                var locale = new LocaleSetting()
                {
                    Timezone = "Australia/Canberra",
                    SiteId = createResult.Data.First().Id
                };
                
                var result = await unifiClient.SetSiteLocaleAsync(locale, createResult.Data.First().Name);
                result.Result.ShouldBe(true);

                await unifiClient.DeleteSiteAsync(createResult.Data.First().Id);
            }
        }
        [Fact]
        public async Task ShouldListSiteSettings()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListSiteSettingsAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }


        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldDeleteSite()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateSiteAsync("DeleteSite");
                createResult.ShouldNotBeNull();
                createResult.Meta.Rc.ToLower().ShouldBe("ok");

                var result = await unifiClient.DeleteSiteAsync(createResult.Data.First().Id);
                result.Result.ShouldBe(true);
            }
        }

        [Fact]
        public void ShouldValidateVersionMissingAttribute()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("1.1.1");
                unifiClient.Version.IsValid().ShouldBe(true);
            }
        }
        [Fact]
        [MinimumVersionRequired("1.1.0")]
        public void ShouldValidateVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("1.1.1");
                unifiClient.Version.IsValid().ShouldBe(true);
            }
        }
        [Fact]
        [MinimumVersionRequired("1.1.2")]
        public void ShouldFailOnBuildVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("1.1.1");
                unifiClient.Version.IsValid().ShouldBe(false);
            }
        }
        [Fact]
        [MinimumVersionRequired("1.2.2")]
        public void ShouldFailOnMinorVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("1.1.3");
                unifiClient.Version.IsValid().ShouldBe(false);
            }
        }
        [Fact]
        [MinimumVersionRequired("2.2.3")]
        public void ShouldFailOnMajorVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("1.2.3");
                unifiClient.Version.IsValid().ShouldBe(false);
            }
        }
        [Fact]
        [MinimumVersionRequired("2.2")]
        public void ShouldValidate2PointVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("2.2.3");
                unifiClient.Version.IsValid().ShouldBe(true);
            }
        }
        [Fact]
        [MinimumVersionRequired("2.2")]
        public void ShouldValidateSame2PointVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("2.2.0");
                unifiClient.Version.IsValid().ShouldBe(true);
            }
        }
        [Fact]
        [MinimumVersionRequired("2.2")]
        public void ShouldFail2PointVersion()
        {
            using (var unifiClient = new Client(_url))
            {
                unifiClient.Version = Version.Parse("2.1.7");
                unifiClient.Version.IsValid().ShouldBe(false);
            }
        }
        [Fact]
        public async Task ShouldGetListOfSitesStats()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListSitesStatsAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
                result.Data.First().Health.Count.ShouldBeGreaterThanOrEqualTo(1);

            }
        }
        [Fact]
        public async Task ShouldGetGetSystemInfo()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.GetSystemInfoAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                result.Data.First().Name.Length.ShouldBeGreaterThan(0);
            }
        }

        [Fact(Skip = "Needs MAC Address Set")]
        public async Task ShouldGetClientDetails()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ClientDetailsAsync("{set mac address}");
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
            }
        }
        [Fact(Skip = "Needs MAC Address Set")]
        public async Task ShouldGetClientLogins()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ShowClientLoginsAsync("{set mac address}");
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
            }
        }
        [Fact]
        public async Task ShouldGetAllClients()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListAllClientsAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
            }
        }
        [Fact]
        public async Task ShouldGetAllKnownClients()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListKnownClientsAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThan(0);
            }
        }
        [Fact]
        public async Task ShouldGetAllOnlineClients()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListOnlineClientsAsync();
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public async Task ShouldGetSpecificOnlineClient()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var onlineClientsResult = await unifiClient.ListOnlineClientsAsync();

                var result = await unifiClient.ListOnlineClientsAsync(onlineClientsResult.Data.First().Mac);
                result.ShouldNotBeNull();
                result.Meta.Rc.ToLower().ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBe(1);
            }
        }

        [Fact]
        public async Task ShouldBeAbleToBlockClient()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var onlineClientsResult = await unifiClient.ListOnlineClientsAsync();

                var result = await unifiClient.BlockClientAsync(onlineClientsResult.Data.First().Mac);
                result.Result.ShouldBe(true);

                await unifiClient.UnblockClientAsync(onlineClientsResult.Data.First().Mac);
            }
        }

        [Fact]
        public async Task ShouldBeAbleToUnblockClient()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var onlineClientsResult = await unifiClient.ListOnlineClientsAsync();

                var blockResult = await unifiClient.BlockClientAsync(onlineClientsResult.Data.First().Mac);
                blockResult.Result.ShouldBe(true);

                var result = await unifiClient.UnblockClientAsync(onlineClientsResult.Data.First().Mac);
                result.Result.ShouldBe(true);
            }
        }

        [Fact(Skip = "Demo Site doesn't return notes / doesn't save notes")]
        public async Task ShouldBeAbleToAddClientNote()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var onlineClientsResult = await unifiClient.ListAllClientsAsync();
                var macAddress = onlineClientsResult.Data.First().Mac;
                var noteValue = $"Note Added {DateTime.Now:s}";
                var addNoteResult = await unifiClient.AddClientNoteAsync(macAddress, noteValue);
                addNoteResult.Result.ShouldBe(true);

                var checkNoteResult = await unifiClient.ClientDetailsAsync(macAddress);
                checkNoteResult.Meta.Rc.ToLower().ShouldBe("ok");
                checkNoteResult.Data.ShouldNotBeNull();
                checkNoteResult.Data.First().Noted.ShouldBe(true);
            }
        }
        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToCreateUserGroup()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.CreateUserGroupAsync("Test Group", 100, 100);
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                result.Data.First().Id.ShouldNotBeEmpty();
                result.Data.First().Name.ShouldBe("Test Group");
                result.Data.First().QosRateMaxDown.ShouldBe(100);
                result.Data.First().QosRateMaxUp.ShouldBe(100);

                var deleteResult = await unifiClient.DeleteUserGroupAsync(result.Data.First().Id);
            }
        }
        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToUpdateUserGroup()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var updateResult = await unifiClient.CreateUserGroupAsync("Test Group", 100, 100);
                updateResult.Meta.Rc.ShouldBe("ok");
                updateResult.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                updateResult.Data.First().Id.ShouldNotBeEmpty();
                updateResult.Data.First().Name.ShouldBe("Test Group");
                updateResult.Data.First().QosRateMaxDown.ShouldBe(100);
                updateResult.Data.First().QosRateMaxUp.ShouldBe(100);

                var group = updateResult.Data.First();

                var result = await unifiClient.UpdateUserGroupAsync(group.Id, group.SiteId, group.Name + " Updated", 50, 50);
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                result.Data.First().Id.ShouldNotBeEmpty();
                result.Data.First().Name.ShouldBe("Test Group Updated");
                result.Data.First().QosRateMaxDown.ShouldBe(50);
                result.Data.First().QosRateMaxUp.ShouldBe(50);

                var deleteResult = await unifiClient.DeleteUserGroupAsync(group.Id);
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToDeleteUserGroup()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var updateResult = await unifiClient.CreateUserGroupAsync("Test Group", 100, 100);
                updateResult.Meta.Rc.ShouldBe("ok");
                updateResult.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
               
                var group = updateResult.Data.First();

                var result = await unifiClient.DeleteUserGroupAsync(group.Id);
                result.Result.ShouldBe(true);
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToAssignDeviceToUserGroup()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var updateResult = await unifiClient.CreateUserGroupAsync("Test Group", 100, 100);
                updateResult.Meta.Rc.ShouldBe("ok");
                updateResult.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
               
                var group = updateResult.Data.First();

                var clients = await unifiClient.ListOnlineClientsAsync();
                var client = clients.Data.First();
                var result = await unifiClient.AssignClientToUserGroupAsync(client.Id, group.Id);
                result.Result.ShouldBe(true);

                var deleteResult = await unifiClient.DeleteUserGroupAsync(group.Id);
                deleteResult.Result.ShouldBe(true);
            }
        }

        [Fact]
        public async Task ShouldBeAbleToListUserGroups()
        {
            using (var unifiClient = new Client(_url))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListUserGroupsAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                result.Data.First().Id.ShouldNotBeEmpty();
            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToCreateFirewallGroup()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.CreateFirewallGroupAsync("CreateTest", GroupType.AddressGroup, new List<string>{ "1.0.0.1" });
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                var fwGroup = result.Data.First();
                fwGroup.Id.ShouldNotBeEmpty();
                fwGroup.Name.ShouldBe("CreateTest");

                var deleteResult = await unifiClient.DeleteFirewallGroupAsync(fwGroup.Id);
            }
        }
        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToUpdateFirewallGroupName()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateFirewallGroupAsync("UpdateTest", GroupType.AddressGroup, new List<string> { "1.0.0.1" });
                createResult.Meta.Rc.ShouldBe("ok");
                createResult.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                var createdGroup = createResult.Data.First();

                var result = await unifiClient.UpdateFirewallGroupAsync(createdGroup.Id, createdGroup.SiteId, "UpdatedTest", createdGroup.GroupType, createdGroup.GroupMembers);
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                var updatedGroup = result.Data.First();
                updatedGroup.Name.ShouldBe("UpdatedTest");

                var deleteResult = await unifiClient.DeleteFirewallGroupAsync(createdGroup.Id);
            }
        }
        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToGetFirewallGroups()
        {
            using (var unifiClient = new Client(_url,null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateFirewallGroupAsync("ListTest", GroupType.AddressGroup, new List<string> { "1.0.0.1" });
                createResult.Meta.Rc.ShouldBe("ok");
                createResult.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                var createdGroup = createResult.Data.First();

                var result = await unifiClient.ListFirewallGroupsAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
                var fwGroup = result.Data.FirstOrDefault(x => x.Name.Equals("ListTest"));
                fwGroup.ShouldNotBeNull();
                fwGroup.Id.ShouldBe(createdGroup.Id);

                var deleteResult = await unifiClient.DeleteFirewallGroupAsync(createdGroup.Id);

            }
        }

        [Fact(Skip = "Fail's on Default Demo Site")]
        public async Task ShouldBeAbleToDeleteFirewallGroup()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var createResult = await unifiClient.CreateFirewallGroupAsync("DeleteTest", GroupType.AddressGroup, new List<string> { "1.0.0.2" });
                createResult.Meta.Rc.ShouldBe("ok");
                var fwGroup = createResult.Data.First();

                var result = await unifiClient.DeleteFirewallGroupAsync(fwGroup.Id);
                result.Result.ShouldBe(true);
            }
        }

        [Fact]
        public async Task ShouldBeAbleToListHealth()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListHealthAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(5);
            }
        }
        [Fact]
        public async Task ShouldBeAbleToListDashboardMetricsHrly()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListDashboardAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeInRange(24, 25);
            }
        }
        [Fact]
        public async Task ShouldBeAbleToListDashboardMetrics5Min()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListDashboardAsync(true);
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeInRange(280, 292);
            }
        }
        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToListAllDevices()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListDevicesAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToListDeviceTags()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListDeviceTagsAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public async Task ShouldBeAbleToListRougeAp()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListRougeApAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact (Skip = "Can't guarantee there are rouge ap's")]
        public async Task ShouldBeAbleToListKnownRougeAp()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ListKnownRougeApAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.ShouldNotBeNull();
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact(Skip = "Needs MAC Address Set")]
        public async Task ShouldBeAbleToAdoptDevice()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.AdoptDeviceAsync("{ set mac address}");
                result.Result.ShouldBe(true);
            }
        }

        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToRestartDevice()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var deviceList = await unifiClient.ListDevicesAsync();

                var result = await unifiClient.RestartDeviceAsync(deviceList.Data.First().Mac);
                result.Result.ShouldBe(true);
            }
        }

        [Fact (Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToDisableAp()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var deviceList = await unifiClient.ListDevicesAsync();

                var result = await unifiClient.DisableApAsync(deviceList.Data.First().DeviceId);
                result.Result.ShouldBe(true);

                await unifiClient.DisableApAsync(deviceList.Data.First().DeviceId, false);
            }
        }
        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToOverrideLed()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var deviceList = await unifiClient.ListDevicesAsync();

                var result = await unifiClient.OverrideLedAsync(deviceList.Data.First().DeviceId, Enumerations.OverrideMode.On);
                result.Result.ShouldBe(true);

                await unifiClient.OverrideLedAsync(deviceList.Data.First().Mac, Enumerations.OverrideMode.Default);
            }
        }

        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToToggleDevice()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var deviceList = await unifiClient.ListDevicesAsync();

                var result = await unifiClient.LocateDeviceAsync(deviceList.Data.First().Mac, true);
                result.Result.ShouldBe(true);

                await unifiClient.LocateDeviceAsync(deviceList.Data.First().Mac, false);
            }
        }

        [Fact(Skip = "Fail's on demo site due.")]
        public async Task ShouldBeAbleToToggleSiteLed()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var result = await unifiClient.ToggleSiteLedsAsync(true);
                result.Result.ShouldBe(true);
            }
        }

        [Fact(Skip = "Fail's on demo site due.")]
        public async Task ShouldBeAbleToSetSnmp()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();

                var site = await unifiClient.GetSiteDetailAsync();

                var smtpSetting = new SnmpSetting
                {
                    Community = "SetSnmp",
                    Enabled = true,
                    SiteId = site.Id
                };
                var result = await unifiClient.SetSiteSnmp("", smtpSetting);
                result.Result.ShouldBe(true);
            }
        }
        [Fact(Skip = "Fail's on demo site due to a bad MAC result in the Device Lists")]
        public async Task ShouldBeAbleToRenameDevice()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();
                var deviceList = await unifiClient.ListDevicesAsync();

                var result = await unifiClient.RenameDeviceAsync(deviceList.Data.First().DeviceId, "Test");
                result.Result.ShouldBe(true);

                await unifiClient.RenameDeviceAsync(deviceList.Data.First().DeviceId, deviceList.Data.First().Name);
            }
        }

        [Fact(Skip = "Fail's on demo site due to no backups available")]
        public async Task ShouldBeAbleToListBackups()
        {
            using (var unifiClient = new Client(_url, null, true))
            {
                var loginResult = await unifiClient.LoginAsync(_user, _pass);
                loginResult.Result.ShouldBeTrue();
                
                var result = await unifiClient.ListBackupsAsync();
                result.Meta.Rc.ShouldBe("ok");
                result.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
            }
        }
    }
}
