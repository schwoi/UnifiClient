using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UnifiApi.Models
{
    public partial class Device
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_uptime")]
        public long Uptime { get; set; }

        [JsonProperty("adopt_ip")]
        public string AdoptIp { get; set; }

        [JsonProperty("adopt_manual")]
        public bool AdoptManual { get; set; }

        [JsonProperty("adopt_state")]
        public long AdoptState { get; set; }

        [JsonProperty("adopt_status")]
        public long AdoptStatus { get; set; }

        [JsonProperty("adopt_tries")]
        public long AdoptTries { get; set; }

        [JsonProperty("adopt_url")]
        public string AdoptUrl { get; set; }

        [JsonProperty("adopted")]
        public bool Adopted { get; set; }

        [JsonProperty("antenna_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<AntennaTable> AntennaTable { get; set; }

        [JsonProperty("board_rev", NullValueHandling = NullValueHandling.Ignore)]
        public long? BoardRev { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }

        [JsonProperty("bytes-d", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytesD { get; set; }

        [JsonProperty("bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytesR { get; set; }

        [JsonProperty("cfgversion")]
        public string Cfgversion { get; set; }

        [JsonProperty("config_network")]
        public ConfigNetwork ConfigNetwork { get; set; }

        [JsonProperty("connect_request_ip")]
        public string ConnectRequestIp { get; set; }

        [JsonProperty("connect_request_port")]
        public long ConnectRequestPort { get; set; }

        [JsonProperty("countrycode_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> CountrycodeTable { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("discovered_via")]
        public string DiscoveredVia { get; set; }

        [JsonProperty("downlink_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<DownlinkTable> DownlinkTable { get; set; }

        [JsonProperty("ethernet_table")]
        public List<EthernetTable> EthernetTable { get; set; }

        [JsonProperty("fw_caps")]
        public long FwCaps { get; set; }

        [JsonProperty("guest-num_sta")]
        public long GuestNumSta { get; set; }

        [JsonProperty("guest_token", NullValueHandling = NullValueHandling.Ignore)]
        public string GuestToken { get; set; }

        [JsonProperty("has_eth1", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasEth1 { get; set; }

        [JsonProperty("has_speaker", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasSpeaker { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("hw_caps")]
        public long HwCaps { get; set; }

        [JsonProperty("inform_ip")]
        public string InformIp { get; set; }

        [JsonProperty("inform_url")]
        public string InformUrl { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("isolated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Isolated { get; set; }

        [JsonProperty("known_cfgversion")]
        public string KnownCfgversion { get; set; }

        [JsonProperty("last_seen")]
        public long LastSeen { get; set; }

        [JsonProperty("last_uplink", NullValueHandling = NullValueHandling.Ignore)]
        public LastUplink LastUplink { get; set; }

        [JsonProperty("led_override")]
        public string LedOverride { get; set; }

        [JsonProperty("license_state")]
        public string LicenseState { get; set; }

        [JsonProperty("locating")]
        public bool Locating { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("map_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MapId { get; set; }

        [JsonProperty("meshv3_peer_mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Meshv3PeerMac { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("num_sta")]
        public long NumSta { get; set; }

        [JsonProperty("port_table")]
        public List<PortTable> PortTable { get; set; }

        [JsonProperty("radio_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<RadioTable> RadioTable { get; set; }

        [JsonProperty("radio_table_stats", NullValueHandling = NullValueHandling.Ignore)]
        public List<RadioTableStat> RadioTableStats { get; set; }

        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_bytes-d", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBytesD { get; set; }

        [JsonProperty("scan_radio_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> ScanRadioTable { get; set; }

        [JsonProperty("scanning", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scanning { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("spectrum_scanning", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SpectrumScanning { get; set; }

        [JsonProperty("ssh_session_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> SshSessionTable { get; set; }

        [JsonProperty("sshd_port")]
        public long SshdPort { get; set; }

        [JsonProperty("stat")]
        public Stat Stat { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("sys_stats")]
        public SysStats SysStats { get; set; }

        [JsonProperty("system-stats")]
        public SystemStats SystemStats { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_bytes-d", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBytesD { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("upgradable")]
        public bool Upgradable { get; set; }

        [JsonProperty("upgrade_state", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpgradeState { get; set; }

        [JsonProperty("upgrade_to_firmware", NullValueHandling = NullValueHandling.Ignore)]
        public string UpgradeToFirmware { get; set; }

        [JsonProperty("uplink")]
        public Uplink Uplink { get; set; }

        [JsonProperty("uplink_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> UplinkTable { get; set; }

        [JsonProperty("uptime")]
        public long DatumUptime { get; set; }

        [JsonProperty("user-num_sta")]
        public long UserNumSta { get; set; }

        [JsonProperty("vap_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<VapTable> VapTable { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("version_incompatible")]
        public bool VersionIncompatible { get; set; }

        [JsonProperty("vwireEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VwireEnabled { get; set; }

        [JsonProperty("vwire_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> VwireTable { get; set; }

        [JsonProperty("vwire_vap_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> VwireVapTable { get; set; }

        [JsonProperty("wifi_caps", NullValueHandling = NullValueHandling.Ignore)]
        public long? WifiCaps { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public long? X { get; set; }

        [JsonProperty("x_authkey")]
        public string XAuthkey { get; set; }

        [JsonProperty("x_fingerprint")]
        public string XFingerprint { get; set; }

        [JsonProperty("x_has_ssh_hostkey")]
        public bool XHasSshHostkey { get; set; }

        [JsonProperty("x_inform_authkey")]
        public string XInformAuthkey { get; set; }

        [JsonProperty("x_vwirekey", NullValueHandling = NullValueHandling.Ignore)]
        public string XVwirekey { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public long? Y { get; set; }

        [JsonProperty("x_ssh_hostkey_fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string XSshHostkeyFingerprint { get; set; }

        [JsonProperty("network_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> NetworkTable { get; set; }

        [JsonProperty("num_desktop", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumDesktop { get; set; }

        [JsonProperty("num_handheld", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumHandheld { get; set; }

        [JsonProperty("num_mobile", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumMobile { get; set; }

        [JsonProperty("rollupgrade", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rollupgrade { get; set; }

        [JsonProperty("speedtest-status", NullValueHandling = NullValueHandling.Ignore)]
        public SpeedtestStatus SpeedtestStatus { get; set; }

        [JsonProperty("speedtest-status-saved", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SpeedtestStatusSaved { get; set; }

        [JsonProperty("usg_caps", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsgCaps { get; set; }

        [JsonProperty("wan1", NullValueHandling = NullValueHandling.Ignore)]
        public Wan1 Wan1 { get; set; }

        [JsonProperty("dhcp_server_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> DhcpServerTable { get; set; }

        [JsonProperty("dot1x_portctrl_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Dot1XPortctrlEnabled { get; set; }

        [JsonProperty("fan_level", NullValueHandling = NullValueHandling.Ignore)]
        public long? FanLevel { get; set; }

        [JsonProperty("flowctrl_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FlowctrlEnabled { get; set; }

        [JsonProperty("general_temperature", NullValueHandling = NullValueHandling.Ignore)]
        public long? GeneralTemperature { get; set; }

        [JsonProperty("has_fan", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasFan { get; set; }

        [JsonProperty("has_temperature", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasTemperature { get; set; }

        [JsonProperty("jumboframe_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? JumboframeEnabled { get; set; }

        [JsonProperty("overheating", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Overheating { get; set; }

        [JsonProperty("stp_priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? StpPriority { get; set; }

        [JsonProperty("stp_version", NullValueHandling = NullValueHandling.Ignore)]
        public string StpVersion { get; set; }

        [JsonProperty("total_max_power", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalMaxPower { get; set; }

        [JsonProperty("uplink_depth", NullValueHandling = NullValueHandling.Ignore)]
        public long? UplinkDepth { get; set; }
    }

    public partial class AntennaTable
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("wifi0_gain")]
        public long Wifi0Gain { get; set; }

        [JsonProperty("wifi1_gain")]
        public long Wifi1Gain { get; set; }
    }

    public partial class ConfigNetwork
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class DownlinkTable
    {
        [JsonProperty("full_duplex")]
        public bool FullDuplex { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("port_idx")]
        public long PortIdx { get; set; }

        [JsonProperty("speed")]
        public long Speed { get; set; }
    }

    public partial class EthernetTable
    {
        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("num_port", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumPort { get; set; }
    }

    public partial class LastUplink
    {
        [JsonProperty("uplink_mac")]
        public string UplinkMac { get; set; }

        [JsonProperty("uplink_remote_port", NullValueHandling = NullValueHandling.Ignore)]
        public long? UplinkRemotePort { get; set; }
    }

    public partial class PortTable
    {
        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("full_duplex")]
        public bool FullDuplex { get; set; }

        [JsonProperty("ifname", NullValueHandling = NullValueHandling.Ignore)]
        public string Ifname { get; set; }

        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("netmask", NullValueHandling = NullValueHandling.Ignore)]
        public string Netmask { get; set; }

        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_dropped")]
        public long RxDropped { get; set; }

        [JsonProperty("rx_errors")]
        public long RxErrors { get; set; }

        [JsonProperty("rx_multicast")]
        public long RxMulticast { get; set; }

        [JsonProperty("rx_packets")]
        public long RxPackets { get; set; }

        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_dropped")]
        public long TxDropped { get; set; }

        [JsonProperty("tx_errors")]
        public long TxErrors { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("up")]
        public bool Up { get; set; }

        [JsonProperty("dns", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dns { get; set; }

        [JsonProperty("gateway", NullValueHandling = NullValueHandling.Ignore)]
        public string Gateway { get; set; }

        [JsonProperty("aggregated_by", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AggregatedBy { get; set; }

        [JsonProperty("autoneg", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Autoneg { get; set; }

        [JsonProperty("bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytesR { get; set; }

        [JsonProperty("dot1x_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Dot1XMode { get; set; }

        [JsonProperty("dot1x_status", NullValueHandling = NullValueHandling.Ignore)]
        public string Dot1XStatus { get; set; }

        [JsonProperty("flowctrl_rx", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FlowctrlRx { get; set; }

        [JsonProperty("flowctrl_tx", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FlowctrlTx { get; set; }

        [JsonProperty("is_uplink", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUplink { get; set; }

        [JsonProperty("jumbo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Jumbo { get; set; }

        [JsonProperty("lldp_table", NullValueHandling = NullValueHandling.Ignore)]
        public List<LldpTable> LldpTable { get; set; }

        [JsonProperty("masked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Masked { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string Media { get; set; }

        [JsonProperty("op_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string OpMode { get; set; }

        [JsonProperty("poe_caps", NullValueHandling = NullValueHandling.Ignore)]
        public long? PoeCaps { get; set; }

        [JsonProperty("port_idx", NullValueHandling = NullValueHandling.Ignore)]
        public long? PortIdx { get; set; }

        [JsonProperty("port_poe", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PortPoe { get; set; }

        [JsonProperty("portconf_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PortconfId { get; set; }

        [JsonProperty("rx_broadcast", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBroadcast { get; set; }

        [JsonProperty("rx_bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBytesR { get; set; }

        [JsonProperty("stp_pathcost", NullValueHandling = NullValueHandling.Ignore)]
        public long? StpPathcost { get; set; }

        [JsonProperty("stp_state", NullValueHandling = NullValueHandling.Ignore)]
        public string StpState { get; set; }

        [JsonProperty("tx_broadcast", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBroadcast { get; set; }

        [JsonProperty("tx_bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBytesR { get; set; }

        [JsonProperty("tx_multicast", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxMulticast { get; set; }

        [JsonProperty("sfp_found", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SfpFound { get; set; }

        [JsonProperty("poe_class", NullValueHandling = NullValueHandling.Ignore)]
        public string PoeClass { get; set; }

        [JsonProperty("poe_current", NullValueHandling = NullValueHandling.Ignore)]
        public string PoeCurrent { get; set; }

        [JsonProperty("poe_enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PoeEnable { get; set; }

        [JsonProperty("poe_good", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PoeGood { get; set; }

        [JsonProperty("poe_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string PoeMode { get; set; }

        [JsonProperty("poe_power", NullValueHandling = NullValueHandling.Ignore)]
        public string PoePower { get; set; }

        [JsonProperty("poe_voltage", NullValueHandling = NullValueHandling.Ignore)]
        public string PoeVoltage { get; set; }
    }

    public partial class LldpTable
    {
        [JsonProperty("lldp_chassis_id")]
        public string LldpChassisId { get; set; }

        [JsonProperty("lldp_port_id")]
        public string LldpPortId { get; set; }

        [JsonProperty("lldp_system_name")]
        public string LldpSystemName { get; set; }
    }

    public partial class RadioTable
    {
        [JsonProperty("antenna_gain")]
        public long AntennaGain { get; set; }

        [JsonProperty("antenna_id")]
        public long AntennaId { get; set; }

        [JsonProperty("builtin_ant_gain")]
        public long BuiltinAntGain { get; set; }

        [JsonProperty("builtin_antenna")]
        public bool BuiltinAntenna { get; set; }

        [JsonProperty("current_antenna_gain")]
        public long CurrentAntennaGain { get; set; }

        [JsonProperty("max_txpower")]
        public long MaxTxpower { get; set; }

        [JsonProperty("min_txpower")]
        public long MinTxpower { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nss")]
        public long Nss { get; set; }

        [JsonProperty("radio")]
        public string Radio { get; set; }

        [JsonProperty("radio_caps")]
        public long RadioCaps { get; set; }

        [JsonProperty("wlangroup_id")]
        public string WlangroupId { get; set; }

        [JsonProperty("has_dfs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDfs { get; set; }

        [JsonProperty("has_fccdfs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasFccdfs { get; set; }

        [JsonProperty("is_11ac", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Is11Ac { get; set; }
    }

    public partial class RadioTableStat
    {
        [JsonProperty("ast_be_xmit")]
        public dynamic AstBeXmit { get; set; }

        [JsonProperty("ast_cst")]
        public dynamic AstCst { get; set; }

        [JsonProperty("ast_txto")]
        public dynamic AstTxto { get; set; }

        [JsonProperty("channel")]
        public long Channel { get; set; }

        [JsonProperty("cu_self_rx")]
        public long CuSelfRx { get; set; }

        [JsonProperty("cu_self_tx")]
        public long CuSelfTx { get; set; }

        [JsonProperty("cu_total")]
        public long CuTotal { get; set; }

        [JsonProperty("extchannel")]
        public long Extchannel { get; set; }

        [JsonProperty("gain")]
        public long Gain { get; set; }

        [JsonProperty("guest-num_sta")]
        public long GuestNumSta { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("num_sta")]
        public long NumSta { get; set; }

        [JsonProperty("radio")]
        public string Radio { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("tx_power")]
        public long TxPower { get; set; }

        [JsonProperty("tx_retries")]
        public long TxRetries { get; set; }

        [JsonProperty("user-num_sta")]
        public long UserNumSta { get; set; }
    }

    public partial class SpeedtestStatus
    {
        [JsonProperty("latency")]
        public long Latency { get; set; }

        [JsonProperty("rundate")]
        public long Rundate { get; set; }

        [JsonProperty("runtime")]
        public long Runtime { get; set; }

        [JsonProperty("status_download")]
        public long StatusDownload { get; set; }

        [JsonProperty("status_ping")]
        public long StatusPing { get; set; }

        [JsonProperty("status_summary")]
        public long StatusSummary { get; set; }

        [JsonProperty("status_upload")]
        public long StatusUpload { get; set; }

        [JsonProperty("xput_download")]
        public double XputDownload { get; set; }

        [JsonProperty("xput_upload")]
        public double XputUpload { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("ap", NullValueHandling = NullValueHandling.Ignore)]
        public string Ap { get; set; }

        [JsonProperty("bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Bytes { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("guest-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxBytes { get; set; }

        [JsonProperty("guest-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxCrypts { get; set; }

        [JsonProperty("guest-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxDropped { get; set; }

        [JsonProperty("guest-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxErrors { get; set; }

        [JsonProperty("guest-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxFrags { get; set; }

        [JsonProperty("guest-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestRxPackets { get; set; }

        [JsonProperty("guest-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestTxBytes { get; set; }

        [JsonProperty("guest-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestTxDropped { get; set; }

        [JsonProperty("guest-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestTxErrors { get; set; }

        [JsonProperty("guest-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestTxPackets { get; set; }

        [JsonProperty("guest-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? GuestTxRetries { get; set; }

        [JsonProperty("o")]
        public string DeviceType { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBytes { get; set; }

        [JsonProperty("rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxCrypts { get; set; }

        [JsonProperty("rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxDropped { get; set; }

        [JsonProperty("rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxErrors { get; set; }

        [JsonProperty("rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxFrags { get; set; }

        [JsonProperty("rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxPackets { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBytes { get; set; }

        [JsonProperty("tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxDropped { get; set; }

        [JsonProperty("tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxErrors { get; set; }

        [JsonProperty("tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxPackets { get; set; }

        [JsonProperty("tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxRetries { get; set; }

        [JsonProperty("user-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxBytes { get; set; }

        [JsonProperty("user-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxCrypts { get; set; }

        [JsonProperty("user-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxDropped { get; set; }

        [JsonProperty("user-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxErrors { get; set; }

        [JsonProperty("user-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxFrags { get; set; }

        [JsonProperty("user-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserRxPackets { get; set; }

        [JsonProperty("user-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserTxBytes { get; set; }

        [JsonProperty("user-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserTxDropped { get; set; }

        [JsonProperty("user-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserTxErrors { get; set; }

        [JsonProperty("user-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserTxPackets { get; set; }

        [JsonProperty("user-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserTxRetries { get; set; }

        [JsonProperty("user-wifi0-ath0-5b3baacf46e0fb0100576dbf-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0Ath05B3Baacf46E0Fb0100576DbfRxBytes { get; set; }

        [JsonProperty("user-wifi0-ath0-5b3baacf46e0fb0100576dbf-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0Ath05B3Baacf46E0Fb0100576DbfRxPackets { get; set; }

        [JsonProperty("user-wifi0-ath0-5b3baacf46e0fb0100576dbf-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0Ath05B3Baacf46E0Fb0100576DbfTxBytes { get; set; }

        [JsonProperty("user-wifi0-ath0-5b3baacf46e0fb0100576dbf-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0Ath05B3Baacf46E0Fb0100576DbfTxPackets { get; set; }

        [JsonProperty("user-wifi0-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxBytes { get; set; }

        [JsonProperty("user-wifi0-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxCrypts { get; set; }

        [JsonProperty("user-wifi0-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxDropped { get; set; }

        [JsonProperty("user-wifi0-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxErrors { get; set; }

        [JsonProperty("user-wifi0-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxFrags { get; set; }

        [JsonProperty("user-wifi0-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0RxPackets { get; set; }

        [JsonProperty("user-wifi0-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0TxBytes { get; set; }

        [JsonProperty("user-wifi0-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0TxDropped { get; set; }

        [JsonProperty("user-wifi0-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0TxErrors { get; set; }

        [JsonProperty("user-wifi0-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0TxPackets { get; set; }

        [JsonProperty("user-wifi0-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi0TxRetries { get; set; }

        [JsonProperty("user-wifi1-ath2-5b3baad046e0fb0100576dc1-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1Ath25B3Baad046E0Fb0100576Dc1RxBytes { get; set; }

        [JsonProperty("user-wifi1-ath2-5b3baad046e0fb0100576dc1-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1Ath25B3Baad046E0Fb0100576Dc1RxPackets { get; set; }

        [JsonProperty("user-wifi1-ath2-5b3baad046e0fb0100576dc1-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1Ath25B3Baad046E0Fb0100576Dc1TxBytes { get; set; }

        [JsonProperty("user-wifi1-ath2-5b3baad046e0fb0100576dc1-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1Ath25B3Baad046E0Fb0100576Dc1TxPackets { get; set; }

        [JsonProperty("user-wifi1-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxBytes { get; set; }

        [JsonProperty("user-wifi1-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxCrypts { get; set; }

        [JsonProperty("user-wifi1-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxDropped { get; set; }

        [JsonProperty("user-wifi1-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxErrors { get; set; }

        [JsonProperty("user-wifi1-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxFrags { get; set; }

        [JsonProperty("user-wifi1-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1RxPackets { get; set; }

        [JsonProperty("user-wifi1-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1TxBytes { get; set; }

        [JsonProperty("user-wifi1-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1TxDropped { get; set; }

        [JsonProperty("user-wifi1-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1TxErrors { get; set; }

        [JsonProperty("user-wifi1-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1TxPackets { get; set; }

        [JsonProperty("user-wifi1-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserWifi1TxRetries { get; set; }

        [JsonProperty("wifi0-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxBytes { get; set; }

        [JsonProperty("wifi0-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxCrypts { get; set; }

        [JsonProperty("wifi0-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxDropped { get; set; }

        [JsonProperty("wifi0-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxErrors { get; set; }

        [JsonProperty("wifi0-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxFrags { get; set; }

        [JsonProperty("wifi0-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0RxPackets { get; set; }

        [JsonProperty("wifi0-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0TxBytes { get; set; }

        [JsonProperty("wifi0-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0TxDropped { get; set; }

        [JsonProperty("wifi0-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0TxErrors { get; set; }

        [JsonProperty("wifi0-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0TxPackets { get; set; }

        [JsonProperty("wifi0-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi0TxRetries { get; set; }

        [JsonProperty("wifi1-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxBytes { get; set; }

        [JsonProperty("wifi1-rx_crypts", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxCrypts { get; set; }

        [JsonProperty("wifi1-rx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxDropped { get; set; }

        [JsonProperty("wifi1-rx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxErrors { get; set; }

        [JsonProperty("wifi1-rx_frags", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxFrags { get; set; }

        [JsonProperty("wifi1-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1RxPackets { get; set; }

        [JsonProperty("wifi1-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1TxBytes { get; set; }

        [JsonProperty("wifi1-tx_dropped", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1TxDropped { get; set; }

        [JsonProperty("wifi1-tx_errors", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1TxErrors { get; set; }

        [JsonProperty("wifi1-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1TxPackets { get; set; }

        [JsonProperty("wifi1-tx_retries", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wifi1TxRetries { get; set; }

        [JsonProperty("gw", NullValueHandling = NullValueHandling.Ignore)]
        public string Gw { get; set; }

        [JsonProperty("wan-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? WanRxBytes { get; set; }

        [JsonProperty("wan-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? WanTxBytes { get; set; }

        [JsonProperty("port_1-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port1RxBytes { get; set; }

        [JsonProperty("port_1-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port1RxPackets { get; set; }

        [JsonProperty("port_1-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port1TxBytes { get; set; }

        [JsonProperty("port_1-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port1TxPackets { get; set; }

        [JsonProperty("port_10-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port10RxBytes { get; set; }

        [JsonProperty("port_10-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port10RxPackets { get; set; }

        [JsonProperty("port_10-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port10TxBytes { get; set; }

        [JsonProperty("port_10-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port10TxPackets { get; set; }

        [JsonProperty("port_11-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port11RxBytes { get; set; }

        [JsonProperty("port_11-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port11RxPackets { get; set; }

        [JsonProperty("port_11-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port11TxBytes { get; set; }

        [JsonProperty("port_11-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port11TxPackets { get; set; }

        [JsonProperty("port_12-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port12RxBytes { get; set; }

        [JsonProperty("port_12-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port12RxPackets { get; set; }

        [JsonProperty("port_12-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port12TxBytes { get; set; }

        [JsonProperty("port_12-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port12TxPackets { get; set; }

        [JsonProperty("port_13-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port13RxBytes { get; set; }

        [JsonProperty("port_13-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port13RxPackets { get; set; }

        [JsonProperty("port_13-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port13TxBytes { get; set; }

        [JsonProperty("port_13-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port13TxPackets { get; set; }

        [JsonProperty("port_14-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port14RxBytes { get; set; }

        [JsonProperty("port_14-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port14RxPackets { get; set; }

        [JsonProperty("port_14-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port14TxBytes { get; set; }

        [JsonProperty("port_14-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port14TxPackets { get; set; }

        [JsonProperty("port_15-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port15RxBytes { get; set; }

        [JsonProperty("port_15-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port15RxPackets { get; set; }

        [JsonProperty("port_15-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port15TxBytes { get; set; }

        [JsonProperty("port_15-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port15TxPackets { get; set; }

        [JsonProperty("port_16-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port16RxBytes { get; set; }

        [JsonProperty("port_16-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port16RxPackets { get; set; }

        [JsonProperty("port_16-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port16TxBytes { get; set; }

        [JsonProperty("port_16-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port16TxPackets { get; set; }

        [JsonProperty("port_17-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port17RxBytes { get; set; }

        [JsonProperty("port_17-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port17RxPackets { get; set; }

        [JsonProperty("port_17-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port17TxBytes { get; set; }

        [JsonProperty("port_17-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port17TxPackets { get; set; }

        [JsonProperty("port_18-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port18RxBytes { get; set; }

        [JsonProperty("port_18-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port18RxPackets { get; set; }

        [JsonProperty("port_18-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port18TxBytes { get; set; }

        [JsonProperty("port_18-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port18TxPackets { get; set; }

        [JsonProperty("port_19-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port19RxBytes { get; set; }

        [JsonProperty("port_19-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port19RxPackets { get; set; }

        [JsonProperty("port_19-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port19TxBytes { get; set; }

        [JsonProperty("port_19-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port19TxPackets { get; set; }

        [JsonProperty("port_2-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port2RxBytes { get; set; }

        [JsonProperty("port_2-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port2RxPackets { get; set; }

        [JsonProperty("port_2-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port2TxBytes { get; set; }

        [JsonProperty("port_2-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port2TxPackets { get; set; }

        [JsonProperty("port_20-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port20RxBytes { get; set; }

        [JsonProperty("port_20-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port20RxPackets { get; set; }

        [JsonProperty("port_20-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port20TxBytes { get; set; }

        [JsonProperty("port_20-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port20TxPackets { get; set; }

        [JsonProperty("port_21-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port21RxBytes { get; set; }

        [JsonProperty("port_21-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port21RxPackets { get; set; }

        [JsonProperty("port_21-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port21TxBytes { get; set; }

        [JsonProperty("port_21-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port21TxPackets { get; set; }

        [JsonProperty("port_22-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port22RxBytes { get; set; }

        [JsonProperty("port_22-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port22RxPackets { get; set; }

        [JsonProperty("port_22-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port22TxBytes { get; set; }

        [JsonProperty("port_22-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port22TxPackets { get; set; }

        [JsonProperty("port_23-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port23RxBytes { get; set; }

        [JsonProperty("port_23-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port23RxPackets { get; set; }

        [JsonProperty("port_23-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port23TxBytes { get; set; }

        [JsonProperty("port_23-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port23TxPackets { get; set; }

        [JsonProperty("port_24-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port24RxBytes { get; set; }

        [JsonProperty("port_24-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port24RxPackets { get; set; }

        [JsonProperty("port_24-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port24TxBytes { get; set; }

        [JsonProperty("port_24-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port24TxPackets { get; set; }

        [JsonProperty("port_25-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port25RxBytes { get; set; }

        [JsonProperty("port_25-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port25RxPackets { get; set; }

        [JsonProperty("port_25-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port25TxBytes { get; set; }

        [JsonProperty("port_25-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port25TxPackets { get; set; }

        [JsonProperty("port_26-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port26RxBytes { get; set; }

        [JsonProperty("port_26-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port26RxPackets { get; set; }

        [JsonProperty("port_26-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port26TxBytes { get; set; }

        [JsonProperty("port_26-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port26TxPackets { get; set; }

        [JsonProperty("port_3-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port3RxBytes { get; set; }

        [JsonProperty("port_3-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port3RxPackets { get; set; }

        [JsonProperty("port_3-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port3TxBytes { get; set; }

        [JsonProperty("port_3-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port3TxPackets { get; set; }

        [JsonProperty("port_4-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port4RxBytes { get; set; }

        [JsonProperty("port_4-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port4RxPackets { get; set; }

        [JsonProperty("port_4-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port4TxBytes { get; set; }

        [JsonProperty("port_4-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port4TxPackets { get; set; }

        [JsonProperty("port_5-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port5RxBytes { get; set; }

        [JsonProperty("port_5-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port5RxPackets { get; set; }

        [JsonProperty("port_5-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port5TxBytes { get; set; }

        [JsonProperty("port_5-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port5TxPackets { get; set; }

        [JsonProperty("port_6-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port6RxBytes { get; set; }

        [JsonProperty("port_6-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port6RxPackets { get; set; }

        [JsonProperty("port_6-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port6TxBytes { get; set; }

        [JsonProperty("port_6-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port6TxPackets { get; set; }

        [JsonProperty("port_7-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port7RxBytes { get; set; }

        [JsonProperty("port_7-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port7RxPackets { get; set; }

        [JsonProperty("port_7-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port7TxBytes { get; set; }

        [JsonProperty("port_7-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port7TxPackets { get; set; }

        [JsonProperty("port_8-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port8RxBytes { get; set; }

        [JsonProperty("port_8-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port8RxPackets { get; set; }

        [JsonProperty("port_8-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port8TxBytes { get; set; }

        [JsonProperty("port_8-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port8TxPackets { get; set; }

        [JsonProperty("port_9-rx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port9RxBytes { get; set; }

        [JsonProperty("port_9-rx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port9RxPackets { get; set; }

        [JsonProperty("port_9-tx_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port9TxBytes { get; set; }

        [JsonProperty("port_9-tx_packets", NullValueHandling = NullValueHandling.Ignore)]
        public long? Port9TxPackets { get; set; }

        [JsonProperty("rx_broadcast", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBroadcast { get; set; }

        [JsonProperty("rx_multicast", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxMulticast { get; set; }

        [JsonProperty("sw", NullValueHandling = NullValueHandling.Ignore)]
        public string Sw { get; set; }

        [JsonProperty("tx_broadcast", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBroadcast { get; set; }

        [JsonProperty("tx_multicast", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxMulticast { get; set; }
    }

    public partial class SysStats
    {
        [JsonProperty("loadavg_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Loadavg1 { get; set; }

        [JsonProperty("loadavg_15", NullValueHandling = NullValueHandling.Ignore)]
        public string Loadavg15 { get; set; }

        [JsonProperty("loadavg_5", NullValueHandling = NullValueHandling.Ignore)]
        public string Loadavg5 { get; set; }

        [JsonProperty("mem_buffer", NullValueHandling = NullValueHandling.Ignore)]
        public long? MemBuffer { get; set; }

        [JsonProperty("mem_total", NullValueHandling = NullValueHandling.Ignore)]
        public long? MemTotal { get; set; }

        [JsonProperty("mem_used", NullValueHandling = NullValueHandling.Ignore)]
        public long? MemUsed { get; set; }
    }

    public partial class SystemStats
    {
        [JsonProperty("cpu")]
        public string Cpu { get; set; }

        [JsonProperty("mem")]
        public string Mem { get; set; }

        [JsonProperty("uptime")]
        public long Uptime { get; set; }

        [JsonProperty("temps", NullValueHandling = NullValueHandling.Ignore)]
        public Temps Temps { get; set; }
    }

    public partial class Temps
    {
        [JsonProperty("Board (CPU)")]
        public long BoardCpu { get; set; }

        [JsonProperty("Board (PHY)")]
        public long BoardPhy { get; set; }

        [JsonProperty("CPU")]
        public long Cpu { get; set; }

        [JsonProperty("PHY")]
        public long Phy { get; set; }
    }

    public partial class Uplink
    {
        [JsonProperty("full_duplex")]
        public bool FullDuplex { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("max_speed")]
        public long MaxSpeed { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("netmask")]
        public string Netmask { get; set; }

        [JsonProperty("num_port")]
        public long NumPort { get; set; }

        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_bytes-r")]
        public long RxBytesR { get; set; }

        [JsonProperty("rx_dropped")]
        public long RxDropped { get; set; }

        [JsonProperty("rx_errors")]
        public long RxErrors { get; set; }

        [JsonProperty("rx_multicast")]
        public long RxMulticast { get; set; }

        [JsonProperty("rx_packets")]
        public long RxPackets { get; set; }

        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_bytes-r")]
        public long TxBytesR { get; set; }

        [JsonProperty("tx_dropped")]
        public long TxDropped { get; set; }

        [JsonProperty("tx_errors")]
        public long TxErrors { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("up")]
        public bool Up { get; set; }

        [JsonProperty("uplink_mac", NullValueHandling = NullValueHandling.Ignore)]
        public string UplinkMac { get; set; }

        [JsonProperty("uplink_remote_port", NullValueHandling = NullValueHandling.Ignore)]
        public long? UplinkRemotePort { get; set; }

        [JsonProperty("bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytesR { get; set; }

        [JsonProperty("drops", NullValueHandling = NullValueHandling.Ignore)]
        public long? Drops { get; set; }

        [JsonProperty("enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enable { get; set; }

        [JsonProperty("gateways", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Gateways { get; set; }

        [JsonProperty("latency", NullValueHandling = NullValueHandling.Ignore)]
        public long? Latency { get; set; }

        [JsonProperty("nameservers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Nameservers { get; set; }

        [JsonProperty("speedtest_lastrun", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpeedtestLastrun { get; set; }

        [JsonProperty("speedtest_ping", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpeedtestPing { get; set; }

        [JsonProperty("speedtest_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SpeedtestStatus { get; set; }

        [JsonProperty("uptime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Uptime { get; set; }

        [JsonProperty("xput_down", NullValueHandling = NullValueHandling.Ignore)]
        public double? XputDown { get; set; }

        [JsonProperty("xput_up", NullValueHandling = NullValueHandling.Ignore)]
        public double? XputUp { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string Media { get; set; }

        [JsonProperty("port_idx", NullValueHandling = NullValueHandling.Ignore)]
        public long? PortIdx { get; set; }
    }

    public partial class MacClass
    {
        [JsonProperty("_buffer")]
        public Buffer Buffer { get; set; }
    }

    public partial class Buffer
    {
        [JsonProperty("data")]
        public List<long> Data { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class VapTable
    {
        [JsonProperty("anomalies_bar_chart")]
        public AnomaliesBarChart AnomaliesBarChart { get; set; }

        [JsonProperty("ap_mac")]
        public string ApMac { get; set; }

        [JsonProperty("avg_client_signal")]
        public long AvgClientSignal { get; set; }

        [JsonProperty("bssid")]
        public string Bssid { get; set; }

        [JsonProperty("ccq")]
        public long Ccq { get; set; }

        [JsonProperty("channel")]
        public long Channel { get; set; }

        [JsonProperty("essid")]
        public string Essid { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }

        [JsonProperty("is_wep")]
        public bool IsWep { get; set; }

        [JsonProperty("map_id")]
        public string MapId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("num_sta")]
        public long NumSta { get; set; }

        [JsonProperty("radio")]
        public string Radio { get; set; }

        [JsonProperty("radio_name")]
        public string RadioName { get; set; }

        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_crypts")]
        public long RxCrypts { get; set; }

        [JsonProperty("rx_dropped")]
        public long RxDropped { get; set; }

        [JsonProperty("rx_errors")]
        public long RxErrors { get; set; }

        [JsonProperty("rx_frags")]
        public long RxFrags { get; set; }

        [JsonProperty("rx_nwids")]
        public long RxNwids { get; set; }

        [JsonProperty("rx_packets")]
        public long RxPackets { get; set; }

        [JsonProperty("rx_tcp_stats")]
        public XTcpStats RxTcpStats { get; set; }

        [JsonProperty("satisfaction")]
        public long Satisfaction { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_combined_retries")]
        public long TxCombinedRetries { get; set; }

        [JsonProperty("tx_data_mpdu_bytes")]
        public long TxDataMpduBytes { get; set; }

        [JsonProperty("tx_dropped")]
        public long TxDropped { get; set; }

        [JsonProperty("tx_errors")]
        public long TxErrors { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("tx_power")]
        public long TxPower { get; set; }

        [JsonProperty("tx_retries")]
        public long TxRetries { get; set; }

        [JsonProperty("tx_rts_retries")]
        public long TxRtsRetries { get; set; }

        [JsonProperty("tx_success")]
        public long TxSuccess { get; set; }

        [JsonProperty("tx_tcp_stats")]
        public XTcpStats TxTcpStats { get; set; }

        [JsonProperty("tx_total", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxTotal { get; set; }

        [JsonProperty("up")]
        public bool Up { get; set; }

        [JsonProperty("usage")]
        public string Usage { get; set; }

        [JsonProperty("wlanconf_id")]
        public string WlanconfId { get; set; }

        [JsonProperty("extchannel", NullValueHandling = NullValueHandling.Ignore)]
        public long? Extchannel { get; set; }

        [JsonProperty("tx_latency_avg", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxLatencyAvg { get; set; }

        [JsonProperty("tx_latency_max", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxLatencyMax { get; set; }

        [JsonProperty("tx_latency_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxLatencyMin { get; set; }
    }

    public partial class AnomaliesBarChart
    {
        [JsonProperty("high_tcp_latency")]
        public long HighTcpLatency { get; set; }

        [JsonProperty("high_tcp_packet_loss")]
        public long HighTcpPacketLoss { get; set; }

        [JsonProperty("high_wifi_retries")]
        public long HighWifiRetries { get; set; }

        [JsonProperty("low_phy_rate")]
        public long LowPhyRate { get; set; }

        [JsonProperty("poor_stream_eff")]
        public long PoorStreamEff { get; set; }

        [JsonProperty("sleepy_client")]
        public long SleepyClient { get; set; }

        [JsonProperty("weak_signal")]
        public long WeakSignal { get; set; }
    }

    public partial class XTcpStats
    {
        [JsonProperty("goodbytes")]
        public long Goodbytes { get; set; }

        [JsonProperty("lat_avg")]
        public long LatAvg { get; set; }

        [JsonProperty("lat_max")]
        public long LatMax { get; set; }

        [JsonProperty("lat_min")]
        public long LatMin { get; set; }

        [JsonProperty("stalls")]
        public long Stalls { get; set; }
    }

    public partial class Wan1
    {
        [JsonProperty("bytes-r")]
        public long BytesR { get; set; }

        [JsonProperty("dns")]
        public List<string> Dns { get; set; }

        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("full_duplex")]
        public bool FullDuplex { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("ifname")]
        public string Ifname { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("max_speed")]
        public long MaxSpeed { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("netmask")]
        public string Netmask { get; set; }

        [JsonProperty("rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty("rx_bytes-r")]
        public long RxBytesR { get; set; }

        [JsonProperty("rx_dropped")]
        public long RxDropped { get; set; }

        [JsonProperty("rx_errors")]
        public long RxErrors { get; set; }

        [JsonProperty("rx_multicast")]
        public long RxMulticast { get; set; }

        [JsonProperty("rx_packets")]
        public long RxPackets { get; set; }

        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty("tx_bytes-r")]
        public long TxBytesR { get; set; }

        [JsonProperty("tx_dropped")]
        public long TxDropped { get; set; }

        [JsonProperty("tx_errors")]
        public long TxErrors { get; set; }

        [JsonProperty("tx_packets")]
        public long TxPackets { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("up")]
        public bool Up { get; set; }
    }

    public partial struct MacAddress
    {
        public string String;

        public static implicit operator MacAddress(string String) => new MacAddress { String = String };
    }
}
