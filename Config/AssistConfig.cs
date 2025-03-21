namespace Mu3_Assist.Config
{
    public class AssistConfig
    {
        public CommonConfig Common { get; set; } = new CommonConfig();
        public FixConfig Fix { get; set; } = new FixConfig();


        public class CommonConfig
        {
            public bool Test { get; set; } = true;
            public bool Test2 { get; set; } = false;
            public string adasda { get; set; } = "true";
            public int asda { get; set; } = 1;
        }
        
        public class FixConfig
        {
            public bool Enable { get; set; } = true;
        }
    }
}