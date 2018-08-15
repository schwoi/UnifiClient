## UniFi Controller API client class

A .NET Standard library that provides access to Ubiquiti's **UniFi Controller API**, versions 4.X.X and 5.X.X of the UniFi Controller software are supported.

## Methods and functions supported

Currently this library supports the following methods.
 - Login
 - Logout
 - GetControllerStatus
 - GetSystemInfo
 - ListSites
 - AuthorizeGuest
 - UnauthorizeGurst
 - ExtendGuest
 - ListGuests
 - ClientDetail
 - BlockClient
 - UnblockClient
 - ShowClientLogins
 - ListOnlineClients
 - ListAllClients

## Requirements

Newtonsoft.Json

## Credits

This class is based on the work done by the following developers:
- Art of Wifi: https://github.com/Art-of-WiFi/UniFi-API-client/
- domwo: http://community.ubnt.com/t5/UniFi-Wireless/little-php-class-for-unifi-api/m-p/603051
- fbagnol: https://github.com/fbagnol/class.unifi.php
- and the API as published by Ubiquiti: https://dl.ubnt.com/unifi/5.8.24/unifi_sh_api
