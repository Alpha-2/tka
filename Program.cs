using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace tka
{
    public class Program : Plugin<Config>
    {
        public static readonly Lazy<Program> LI = new Lazy<Program>(valueFactory: () => new Program());
        public Program Instance => LI.Value;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Server server;
        private Handlers.Player player;

        public override void OnEnabled()
        {
            try
            {
                RegisterEvents();
            }
            catch (Exception e)
            {
                Log.Error($"Loading error: {e}");
            }
        }
        public override void OnDisabled()
        {
            UnRegisterEvents();
        }
        public void RegisterEvents()
        {
            server = new Handlers.Server();
            player = new Handlers.Player();
            Server.WaitingForPlayers += server.Start;
        }
        public void UnRegisterEvents()
        {
            Server.WaitingForPlayers -= server.Start;
            player = null;
            server = null;
        }
    }
}
