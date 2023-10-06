namespace PRHD_Lib
{
    public static class DS
    {
        /// 

        public static string[] Fpositive = { "Positive",
            "COVID-19 Positive",
            "SARS-CoV-2 Positive",
            "Positive for COVID-19",
            "Positive for influenza B and COVID-19"};


        /// <summary>
        /// propiedades para la comunicacion con el servidor de test
        /// </summary>
        public static string OrderTestCategory { get { return "Covid-19"; } }
        public static string TypeM { get { return "Molecular"; } } //OrderTestType
        public static string TypeA { get { return "Antigens"; } }//OrderTestType
        public static string SCStartDate { get { return "2023-07-01"; } }//SampleCollectedStartDate
        public static string SCEndDate { get { return "2023-07-30"; } } //SampleCollectedEndDate
        public static string CStartDate { get { return "2023-07-01"; } } //CreatedAtStartDate
        public static string CEndtDate { get { return "2023-07-30"; } } //CreatedAtEndDate
    }
}