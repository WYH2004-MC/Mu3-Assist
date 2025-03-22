namespace Mu3_Assist.Config
{
    public class AssistConfig
    {
        public CheatConfig Cheat { get; set; } = new CheatConfig();
        public CommonConfig Common { get; set; } = new CommonConfig();
        public FixConfig Fix { get; set; } = new FixConfig();

        public class CheatConfig
        {
            public bool FastRestart { get; set; } = false;
            public bool FastSkip { get; set; } = false;
            public bool UnlockEvent { get; set; } = false;
            public bool UnlockMaster { get; set; } = false;
            public bool UnlockMusic { get; set; } = false;
        }

        public class CommonConfig
        {
            public bool InfinityTimer { get; set; } = false;
            public bool SkipWarningScreen { get; set; } = false;
            public bool SkipInformationScreen { get; set; } = false;
        }
        
        public class FixConfig
        {
            public bool DisableEncryption { get; set; } = false;
        }
    }
}