using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SomePOC
{
    public class ReadFile
    {
        public static Dictionary<int, List<string>> wordDict = new Dictionary<int, List<string>>();
        public void CreateWordListfromFile(string path, int maxposiiton)
        {
            string line; 
            int rank = 1;
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                if (!(wordDict.ContainsKey(rank)))
                {
                    wordDict.Add(rank, line);
                }
                else
                {
                    if (wordDict[rank].Length == line.Length)
                    {
                        wordDict.Add(rank, line);
                    }
                    else if (wordDict[rank].Length < line.Length)
                    {
                        foreach (KeyValuePair<int, string> pair in wordDict)
                        {

                            wordDict.Remove(pair.Key);
                            wordDict.Add(pair.Key + 1, pair.Value);
                        }
                        wordDict.Add(rank, line);
                    }
                    else
                    {
                        int higestRank = (wordDict.OrderByDescending(a => a.Key).First()).Key;
                        if (higestRank == 1)
                        {
                            if (wordDict[higestRank].Length == line.Length)
                            {
                                wordDict[rank] = wordDict[rank] + "," + line;
                            }
                            else
                            {
                                wordDict.Add(rank+1, line);
                            }
                        }
                        else
                        {
                            while (higestRank > rank)
                            {
                                if (wordDict[higestRank].Length == line.Length)
                                {
                                    wordDict[higestRank] = wordDict[higestRank] + "," + line;
                                }
                                else if (wordDict[higestRank].Length > line.Length)
                                {

                                    string temp = wordDict[higestRank];
                                    wordDict.Remove(higestRank);
                                    wordDict.Add(higestRank + 1, temp);
                                    wordDict.Add(higestRank, line);
                                }
                                else
                                {
                                    higestRank--;
                                }
                            }
                        }
                    }
                }
            }
        }
        public string GetMaxStringBySize(string path,int pos){
            if (wordDict == null || wordDict.Count==0)
            {
                this.CreateWordListfromFile(path,pos);
            }
            if(wordDict.Count>0)
            {
            var str= (from a in wordDict where a.Key==pos select a);
            }
            return null;
        }
    }
}
