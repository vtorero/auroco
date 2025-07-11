using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AurocoPublicidad.util
{
    public class Global
    {
        public static string sessionUsuario;
        public static string rutaReportes = "bin\\Debug";
       public static string servicio = "https://franz.kvconsult.com";
       // public static string servicio = "http://localhost";
        public static string tokenApi = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InZ0b3Jlcm9AZ21haWwuY29tIn0.j-kQo0Dz4mb9wH3NjeXcurSu0MpBWfqt-AODCMKzpjM";
        public static string urlRuc = "https://dniruc.apisperu.com/api/v1/ruc/";
        public static string urlDNI = "https://dniruc.apisperu.com/api/v1/dni/";
        public static string urlFactura = "https://facturacion.apisperu.com/api/v1/invoice/send";
        
        public static string TokenAuroco = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJ1c2VybmFtZSI6InZ0b3Jlcm8iLCJjb21wYW55IjoiMjAxMTE0MDkzOTEiLCJpYXQiOjE3NDk4Nzc3NzksImV4cCI6ODA1NzA3Nzc3OX0.HYGlq_8mXiFiMqAom5Nh8wlvnVNoqK8hcu4K6VFp7pqF3CHDHwTqfvMw3GAPwMoekiETg9t1LxjAdHsjBjYcQVr0C5Hp10FfFrQXg7ojLHOxK8a3pK4plA21jSSDdM9MEFfBbfRuqB-5uBnfSrMif2ujrX6tZHVPKpyHd4XVTFza7UIbh0o1zeHdIlO0LSVLIXA_N_3Ghzzdn3iV3yJE7nDrgTW1FGUsCzno-osOe8cQBGpt5-7aD6tPXdqL6AvF4uRw39PdJuBh9MnO-2Q44jM8Xpex_qdb21bRD7rUC1dmwfs7mlo9B8tVDCrMyAIGEFRWWwYPD0SdtI6Gprc8xpXDbcbfUJedZo30tqx7kfwdEleZ0FR5fzMSbVCxAkz6bK2Q8bepu6XYSvykdq_0m7JZrQuP-iHX89JArQqkBSaIUe1v-DZdOqngDlulQDL5hkTE7LO6obURBcLihOEA0Yn3AEh_FTiGNtvIb_pywQQYkQl4UPHjOhHThVxhVjQUp1xE3e3Ibre9F7p3Ymp0NvqsM5TUaRinqzvaw7KzhsE67qOgPW3kbFOcNIvDZoUr39k_pOuHopAO5bQThrSum6CbsS3EW4bki97bZMRMReWARiKVP2rSsdspW_UJfpfGmYLtm2gQtwo4bveoTTv6XDyTZifA_uYlovCc7MlbZfk";
        public static string TokenOptimiza = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJ1c2VybmFtZSI6InZ0b3Jlcm8iLCJjb21wYW55IjoiMjA1MDQ2Njg2ODIiLCJpYXQiOjE3NTAxOTE0ODQsImV4cCI6ODA1NzM5MTQ4NH0.hwiSilcOkG39R0xN-K9Ro-vzeUewkZqpWg6Zr20cYWIPc_zFIQI5sBteZg3QN2Cb907WGym4IZPaeClFaCz5waEBnJ8mWy1mx7yQ5Tzm7LbqHhA-6vgpwCla4bywjvb5io_rMJylTvIwzJEjN9FQDA0IL6X_3yWpdvYlWN_12Md_khhwuM9K13PWsE1q-X6ZJ7x3W6wCPd6-KwkJuEZhdAgJpaTTQoy-2KC5ePN7jgzTpGQsi7JoEH8YHm_ieUKuyFSb2rVVPRN2heXEoGBkiSo8oCMDQ1nFqxKXN6iyvqZdTPwcgavjUhyCOfsMAufCStd6j0GBRrWDoItfxb0l545ko7xe4_wQhAoisbj26sNRhTw7bb4DULwkyz1yqCGiWXg_JgWJ7FtiWaY2mTsY2Lj8L8xtD7WacjN3ffRX-_beMli8Iyozw_dzzAY4AeBk3536tCrswitNkHrEn0Exg884F69NcdyCdrAigxjP5TBg4H2fbICPngr9JTWNngvC-oI89r3o7l0Ub40AEFgCjv_jPAiQz7lGZr_kH09Px3cKJT--Q1FBDScJACbjdAgIFq-XeWmotwrwTW7kou9_8u0HftEVW_yS9oHgTcj_woPOWkY1NuvPPgPFTDz6S-W_xXyvX4ELi36bBx_Z7_Ik3NKW2buMhKQFLgdcpQ5N4t4";
        
        public static string nombreAuroco = "AUROCO PUBLICIDAD S A";
        public static string nombreOptimiza = "OPTIMIZA MEDIA SAC";

        public static string DireccionAuroco = "JR. TRINIDAD MORAN 362 ALT. EDIFICIO EL DORADO";
        public static string DireccionOptimiza = "CAL. TRINIDAD MORAN NRO. 362 LIMA LIMA LINCE";
        
        public static string dptoAuroco = "LIMA";
        public static string ProvinciaAuroco = "LIMA";
        public static string DistritoAuroco = "LINCE";
        public static string UbigeoAuroco = "150116";
        
        public static string RucAuroco = "20111409391";
        public static string RucOptimiza = "20504668682";

        public static string ctaRetraccion = "00000- 427055";
        public static string ctaDetOptimiza ="00000-414484";

        //public static string connectionString = "server=localhost;user=root;password=;database=auroco";
        public static string connectionString = "server=kvconsult.com;user=kvconsul_auroco;password=auroco2023;database=kvconsul_auroco";





    }
}
