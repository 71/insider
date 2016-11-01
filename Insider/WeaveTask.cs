using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.Cecil;
using MBF = Microsoft.Build.Framework;

namespace Insider
{
    public sealed class WeaveTask : Task
    {
        [Required]
        public string TargetAssembly { get; set; }
        [Required]
        public string TargetReferences { get; set; }
        [Required]
        public string TargetPath { get; set; }

        bool EncounteredError;

        public override bool Execute()
        {
            try
            {
                using (Weaver weaver = Weaver.Create(TargetAssembly, TargetPath, TargetReferences.Split(';')))
                {
                    weaver.MessageLogged += MessageLogged;
                    weaver.Process();
                }
            }
            catch (Exception e)
            {
                EncounteredError = true;
                MessageLogged(null, new MessageLoggedEventArgs(e.Message, MessageImportance.Error, true));
            }
            
            return !EncounteredError;
        }

        private void MessageLogged(object sender, MessageLoggedEventArgs e)
        {
            if (e.StoppedWeaving)
            {
                BuildEngine.LogErrorEvent(new BuildErrorEventArgs("Weaving", "W00", TargetAssembly, -1, -1, -1, -1, e.Message, "", sender.GetType().FullName));
                EncounteredError = true;
            }
            else
            {
                switch (e.Importance)
                {
                    case MessageImportance.Debug:
                    case MessageImportance.Info:
                        BuildEngine.LogMessageEvent(new BuildMessageEventArgs(e.Message, "", sender.GetType().FullName, e.Importance == MessageImportance.Debug ? MBF.MessageImportance.Low : MBF.MessageImportance.Normal));
                        break;
                    case MessageImportance.Warning:
                        BuildEngine.LogWarningEvent(new BuildWarningEventArgs("Weaving", "W00", TargetAssembly, -1, -1, -1, -1, e.Message, "", sender.GetType().FullName));
                        break;
                }
            }
        }
    }
}
