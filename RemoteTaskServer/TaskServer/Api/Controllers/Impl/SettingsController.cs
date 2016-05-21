﻿#region

using System;
using System.Linq;
using RemoteTaskServer.WebServer;
using UlteriusServer.TaskServer.Api.Serialization;
using UlteriusServer.Utilities;
using vtortola.WebSockets;

#endregion

namespace UlteriusServer.TaskServer.Api.Controllers.Impl
{
    public class SettingsController : ApiController
    {

        private readonly WebSocket _client;
        private readonly Packets _packet;
        private readonly ApiSerializator _serializator = new ApiSerializator();

        public SettingsController(WebSocket client, Packets packet)
        {
            _client = client;
            _packet = packet;
        }


        public void ChangeWebServerPort()
        {
            var port = int.Parse(_packet.Args[0].ToString());
            Settings.Get("WebServer").WebServerPort = port;
            Settings.Save();
            var currentPort = (int) Settings.Get("WebServer").WebServerPort;
            var data = new
            {
                changedStatus = true,
                WebServerPort = currentPort
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeWebFilePath()
        {
            var path = _packet.Args[0].ToString();
            Settings.Get("WebServer").WebFilePath = path;
            Settings.Save();
            var currentPath = (string) Settings.Get("WebServer").WebFilePath;
            var data = new
            {
                changedStatus = true,
                WebFilePath = currentPath
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeVncPassword()
        {
            var pass = _packet.Args[0].ToString();
            Settings.Get("Vnc").VncPass = pass;
            Settings.Save();
            var currentPass = (string) Settings.Get("Vnc").VncPass;
            var data = new
            {
                changedStatus = true,
                VncPass = currentPass
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeVncPort()
        {
            var port = int.Parse(_packet.Args[0].ToString());
            Settings.Get("Vnc").VncPort = port;
            Settings.Save();
            var currentPort = (int) Settings.Get("Vnc").VncPort;
            var data = new
            {
                changedStatus = true,
                VncPort = currentPort
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeVncProxyPort()
        {
            var port = int.Parse(_packet.Args[0].ToString());
            Settings.Get("Vnc").VncProxyPort = port;
            Settings.Save();
            var currentPort = (int) Settings.Get("Vnc").VncProxyPort;
            var data = new
            {
                changedStatus = true,
                VncProxyPort = currentPort
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeWebServerUse()
        {
            var useServer = Convert.ToBoolean(_packet.Args[0]);
            Settings.Get("WebServer").UseWebServer = useServer;
            Settings.Save();
            var currentStatus = (bool) Settings.Get("WebServer").UseWebServer;
            var data = new
            {
                changedStatus = true,
                UseWebServer = currentStatus
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeNetworkResolve()
        {
            var resolve = Convert.ToBoolean(_packet.Args[0]);
            Settings.Get("Network").SkipHostNameResolve = resolve;
            Settings.Save();
            var currentStatus = (bool) Settings.Get("Network").SkipHostNameResolve;
            var data = new
            {
                changedStatus = true,
                SkipHostNameResolve = currentStatus
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeTaskServerPort()
        {
            var port = int.Parse(_packet.Args[0].ToString());
            Settings.Get("TaskServer").TaskServerPort = port;
            Settings.Save();
            var currentPort = (int) Settings.Get("TaskServer").TaskServerPort;
            var data = new
            {
                changedStatus = true,
                TaskServerPort = currentPort
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeLoadPlugins()
        {
            var loadPlugins = Convert.ToBoolean(_packet.Args[0]);
            Settings.Get("Plugins").LoadPlugins = loadPlugins;
            Settings.Save();

            var currentStatus = Convert.ToBoolean(Settings.Get("Plugins").LoadPlugins);
            var data = new
            {
                changedStatus = true,
                LoadPlugins = currentStatus
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void ChangeUseTerminal()
        {
            var useTerminal = Convert.ToBoolean(_packet.Args[0]);
            Settings.Get("Terminal").AllowTerminal = useTerminal;
            Settings.Save();
            var currentStatus = Convert.ToBoolean(Settings.Get("Terminal").AllowTerminal);
            var data = new
            {
                changedStatus = true,
                AllowTerminal = currentStatus
            };
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, data);
        }

        public void GetCurrentSettings()

        {     
            _serializator.Serialize(_client, _packet.Endpoint, _packet.SyncKey, Settings.GetRaw());
        }
    }
}