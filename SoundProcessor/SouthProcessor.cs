using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor {
    static class SouthProcessor {

        public static string Process(string input) {
            string res = input;

            foreach (var market in marketCodes) {
                if (input.StartsWith(market.Key)) {
                    foreach (var branch in branches) {
                        if (input.StartsWith(market.Key + branch.Key)) {
                            if (market.Key == "10") {
                                if (branch.Key == "5" | branch.Key == "8") {
                                    break;
                                } else if (branch.Key == "2") {
                                    res = "0611_" + market.Value + "_credit_";
                                    res += input.Substring((market.Key + "_credit_").Length);
                                } else if (branch.Key == "3") {
                                    res = "0611_" + market.Value + "_corporate_";
                                    res += input.Substring((market.Key + "_corporate_").Length);
                                } else if (branch.Key == "6") {
                                    res = "0611_" + market.Value + "_hlc_";
                                    res += input.Substring((market.Key + "_hlc_").Length);
                                } else if (branch.Key == "122") {
                                    res = "0611_" + market.Value + "_services_";
                                    res += input.Substring((market.Key + "_services_").Length);
                                } else {
                                    res = "0611_" + market.Value + "_" + branch.Value + "_";
                                    res += input.Substring((market.Key + branch.Key).Length);
                                }
                            } else if (market.Key == "11" | market.Key == "12" | market.Key == "13" | market.Key == "14" | market.Key == "19") {
                                if (branch.Key == "3" | branch.Key == "8") {
                                } else if (branch.Key == "2") {
                                    res = "0611_" + market.Value + "_corporate_";
                                    res += input.Substring((market.Key + "_corporate_").Length);
                                } else if (branch.Key == "5") {
                                    res = "0611_" + market.Value + "_hlc_";
                                    res += input.Substring((market.Key + "_hlc_").Length);
                                } else if (branch.Key == "6") {
                                    res = "0611_" + market.Value + "_credit_";
                                    res += input.Substring((market.Key + "_credit_").Length);
                                } else if (branch.Key == "122") {
                                    res = "0611_" + market.Value + "_services_";
                                    res += input.Substring((market.Key + "_services_").Length);
                                } else {
                                    res = "0611_" + market.Value + "_" + branch.Value + "_";
                                    res += input.Substring((market.Key + branch.Key).Length);
                                }
                            } else if (branch.Key == "13" | branch.Key == "17" | branch.Key == "115") {
                                res = market.Value + "_" + branch.Value + "_";
                                res += input.Substring((market.Key + branch.Key).Length);
                            } else if (branch.Key == "124") {
                                res = "0611_" + (market.Value == "10" ? "" : market.Value + "_") + branch.Value + "_";
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
            { "01", "STV" }, //caucasus
            { "02", "caucasus_potential" },
            { "03", "NZR" }, //caucasus
            { "04", "KCH" }, //caucasus
            { "05", "MAH" }, //caucasus
            { "06", "NAL" }, //caucasus
            { "07", "GRZ" }, //caucasus
            { "08", "VLK" }, //caucasus
            { "10", "RND" }, //southRND
            { "11", "AST" }, //south
            { "12", "SCH" }, //south
            { "13", "EST" }, //south
            { "14", "KRD" }, //south
            { "19", "VLG" }, //south
            { "p_", "south_potential" },
        };

        readonly static Dictionary<string, string> branches = new Dictionary<string, string> {
            { "2", "corporate" },
            { "6", "credit" },
            { "8", "hlc" },
            { "122", "STV_services" },
            { "124", "services_loyalnost" },
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
