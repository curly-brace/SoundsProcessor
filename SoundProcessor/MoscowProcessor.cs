using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor {
    static class MoscowProcessor {

        public static string Process(string input) {
            string res = input;

            foreach (var market in marketCodes) {
                if (input.StartsWith(market.Key)) {
                    foreach (var branch in branches) {
                        if (input.StartsWith(market.Key + branch.Key)) {
                            if (branch.Key == "115") {
                                res = market.Value + "_" + branch.Value + "_";
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
            { "01", "VIP" },
            { "02", "VLD" },
            { "03", "IVN" },
            { "04", "KLG" },
            { "05", "KSM" },
            { "06", "RZN" },
            { "07", "SML" },
            { "08", "TVR" },
            { "09", "TUL" },
            { "10", "YRL" },
            { "8", "potential" },
        };
        readonly static Dictionary<string, string> branches = new Dictionary<string, string> {
            { "2", "credit" },
            { "3", "hlc" },
            { "4", "corporate" },
            { "7", "potential" },
            { "12", "prepaid" },
            { "122", "services" },
            { "124", "services_loyalnost" },
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
