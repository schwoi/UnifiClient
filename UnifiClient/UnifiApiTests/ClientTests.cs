using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using UnifiApi;
using Xunit;

namespace UnifiApiTests
{
    public class ClientTests
    {
        //private const string _url = "https://demo.ubnt.com/";
        //private const string _user = "superadmin";
        //private const string _pass = "pq73KF59";
        private const string _url = "https://unifi.schwoi.com/";
    private const string _pass = "bkCDbI4AXGt#NE";
        private const string _user = "admin";
        [Fact]
        public async Task CanAuthenticate()
        {
            using (var unifiClient = new Client(_url))
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

        [Fact(Skip = "Fail's on Default Demo Site")]
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

                var result = await unifiClient.ListAllClients();
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

                var onlineClientsResult = await unifiClient.ListAllClients();
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
        [Fact]
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
        [Fact]
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

        [Fact]
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

        [Fact]
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
    }
}
