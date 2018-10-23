using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor {
    static class SiberiaProcessor {

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
            { "01", "NSK" },
            { "02", "ABK" },
            { "03", "BAR" },
            { "04", "GAL" },
            { "05", "KMR" },
            { "06", "KRS" },
            { "07", "KZL" },
            { "08", "NOR" },
            { "09", "OMS" },
            { "10", "TMS" },
            { "11", "DTI" },
            { "12", "ANR" },
            { "13", "BGK" },
            { "14", "BIR" },
            { "15", "BUR" },
            { "16", "CHT" },
            { "17", "IRK" },
            { "18", "KSK" },
            { "19", "MGD" },
            { "20", "PPK" },
            { "21", "SKH" },
            { "22", "VLA" },
            { "23", "YAK" },
            { "24", "potential" },
        };
        readonly static Dictionary<string, string> branches = new Dictionary<string, string> {
            { "2", "credit" },
            { "3", "corporate" },
            { "6", "hlc" },
            { "122", "services" },
            { "124", "services_loyalnost" },
            { "128", "services_NPS" },
            { "12", "prepaid" },
            { "13", "13" },
            { "17", "17" },
            { "24", "24" },
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
