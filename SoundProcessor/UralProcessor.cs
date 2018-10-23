using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor {
    static class UralProcessor {

        public static string Process(string input) {
            string res = input;

            foreach (var market in marketCodes) {
                if (input.StartsWith(market.Key)) {
                    foreach (var branch in branches) {
                        if (input.StartsWith(market.Key + branch.Key)) {
                            if (branch.Key == "13" | branch.Key == "17" | branch.Key == "115") {
                                res = market.Value + "_" + branch.Value + "_";
                                res += input.Substring((market.Key + branch.Key).Length);
                            } else if (branch.Key == "128") {
                                res = "0611_" + (market.Value == "01" ? "" : market.Value + "_") + branch.Value + "_";
                                res += input.Substring((market.Key + branch.Key).Length);
                            } else {
                                res = "0611_" + market.Value + "_" + branch.Value + "_";
                                res += input.Substring((market.Key + branch.Key).Length);
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            res = res.Replace("_.", ".");
            return res;
        }

        readonly static Dictionary<string, string> marketCodes = new Dictionary<string, string> {
            { "01", "EKT" },
            { "02", "IGK" },
            { "03", "KIR" },
            { "04", "KRG" },
            { "05", "MGN" },
            { "06", "STK" },
            { "07", "YAM" },
            { "08", "PRM" },
            { "09", "HMS" },
            { "10", "SRT" },
            { "11", "NNG" },
            { "12", "PNZ" },
            { "13", "SAM" },
            { "14", "UFA" },
            { "15", "KZN" },
            { "16", "ULN" },
            { "17", "ORB" },
            { "18", "SRN" },
            { "19", "IKO" },
            { "20", "TUM" },
            { "21", "CHL" },
            { "22", "CHB" },
            { "23", "TOL" },
            { "24", "potential" },
        };
        readonly static Dictionary<string, string> branches = new Dictionary<string, string> {
            { "2", "corporate" },
            { "122", "services" },
            { "124", "services_loyalnost" },
            { "128", "services_NPS" },
            { "12", "prepaid" },
            { "13", "13" },
            { "17", "17" },
            { "110", "prepaid_susp" },
            { "111", "prepaid_low" },
            { "112", "prepaid_mid" },
            { "113", "prepaid_high" },
            { "114", "prepaid_young" },
            { "115", "115" },
            { "116", "prepaid_family" },
        };
    }
}
