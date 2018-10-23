using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor {
    static class PiterProcessor {

        public static string Process(string input) {
            string res = input;

            foreach (var market in marketCodes) {
                if (input.StartsWith(market.Key)) {
                    foreach (var branch in branches) {
                        if (input.StartsWith(market.Key + branch.Key)) {
                            if (branch.Key == "13" | branch.Key == "17" | branch.Key == "115") {
                                res = market.Value + "_" + branch.Value + "_";
                                res += input.Substring((market.Key + branch.Key).Length);
                            } else if (branch.Key == "122" | branch.Key == "124" | branch.Key == "128") {
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
            { "01", "SPB" },
            { "02", "ARH" },
            { "03", "VNG" },
            { "04", "VOL" },
            { "05", "MUR" },
            { "06", "KRL" },
            { "07", "PSK" },
            { "09", "EXT" },
            { "10", "VRN" },
            { "11", "BLG" },
            { "12", "ORL" },
            { "13", "KUR" },
            { "14", "LPK" },
            { "15", "TMB" },
            { "16", "BRN" },
        };
        readonly static Dictionary<string, string> branches = new Dictionary<string, string> {
            { "2", "credit" },
            { "3", "corporate" },
            { "6", "hlc" },
            { "08", "potential" },
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
