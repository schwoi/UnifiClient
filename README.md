## UniFi Controller API client class

A .NET Standard library that provides access to Ubiquiti's **UniFi Controller API**, versions 4.X.X and 5.X.X of the UniFi Controller software are supported.

## Wrapper Usage

```csharp
//get all clients on the default site
using (var unifiClient = new Client("https://demo.ubnt.com/"))
{
    await unifiClient.LoginAsync("superuser", "password");
    var result = await unifiClient.ListAllClientsAsync();
}

//get all clients on the default site ignoring invalid certifiate
using (var unifiClient = new Client("https://localhost:8443/", null, true))
{
    await unifiClient.LoginAsync("superuser", "password");
    var result = await unifiClient.ListAllClientsAsync();
}

//get change site
using (var unifiClient = new Client("https://localhost:8443/", null, true))
{
    await unifiClient.LoginAsync("superuser", "password");
    var siteList = await unifiClient.ListSitesAsync();

	unifiClient.Site = result.siteList.FirstOrDefault(x => x.Name != "default")?.Name;
	
	var result = await unifiClient.ListAllClientsAsync();
}

//get all clients by setting the site in the call
using (var unifiClient = new Client("https://localhost:8443/", null, true))
{
    await unifiClient.LoginAsync("superuser", "password");
    var siteList = await unifiClient.ListSitesAsync();

	foreach(var site in result.siteList)
	{
		var result = await unifiClient.ListAllClientsAsync(site.Name);
	}
}

//Set site on connection
using (var unifiClient = new Client("https://localhost:8443/", "abc123", true))
{
}
```

## Methods and functions supported

Currently this library supports the following methods.
 - Login
 - Logout
 - GetControllerStatus
 - ListCountryCodes
 - GetSystemInfo
 - ListSites
 - ListSiteAdmins
 - ListSitesStats
 - ListSiteSettings
 - ListAllAdmins
 - CreateSite
 - RenameSite
 - SetSiteCountry
 - SetSiteLocale
 - SetSiteSnmp
 - SetSiteManagement
 - SetSiteGuestAccess
 - SetSiteNtp
 - SetSiteConnectivity
 - DeleteSite
 - AuthorizeGuest
 - UnauthorizeGuest
 - ExtendGuest
 - ListGuests
 - ClientDetail
 - BlockClient
 - ForgetClient (Alias of ForgetClients)
 - ForgetClients
 - UnblockClient
 - ShowClientLogins
 - ListOnlineClients
 - ListAllClients
 - ListKnownClients
 - AddClientNote (Alias of SetClientNote)
 - RemoveClientNote (Alias of SetClientNote)
 - SetClientNote
 - CreateUserGroup
 - DeleteUserGroup
 - UpdateUserGroup
 - AssignClientToUserGroup
 - ListUserGroups
 - CreateFirewallGroup
 - UpdateFirewallGroup
 - DeleteFirewallGroup
 - ListFirewallGroups
 - ListDevices
 - ListDeviceTags
 - ListRougeAp
 - ListKnownRougeAp
 - AdoptDevice
 - RestartDevice
 - RenameDevice
 - DisableAp
 - OverrideLed
 - LocateDevice
 - SiteLeds
 - ListBackups

## Install
Nuget: https://www.nuget.org/packages/UnifiApi/

Install-Package UnifiApi 

## Requirements

Newtonsoft.Json

## Credits

This class is based on the work done by the following developers:
- Art of Wifi: https://github.com/Art-of-WiFi/UniFi-API-client/
- domwo: http://community.ubnt.com/t5/UniFi-Wireless/little-php-class-for-unifi-api/m-p/603051
- fbagnol: https://github.com/fbagnol/class.unifi.php
- and the API as published by Ubiquiti: https://dl.ubnt.com/unifi/5.8.24/unifi_sh_api
