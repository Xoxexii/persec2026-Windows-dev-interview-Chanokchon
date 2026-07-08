using System.Linq;

bool FirstTest(string input) {
    if(input.Length % 2 != 0) {
        return false;
    }
   int loopamount = input.Length/2;
   bool result = true;
   string[] coupleChecking = {"()", "[]", "{}"};

   for(int i = 0; i < loopamount; i++) {
       if(Array.IndexOf(coupleChecking, $"{input[i]}{input[input.Length - 1 - i]}") < 0) {
           result = false;
           break;
       }
   }
   return result;
}
List<string> SecondTest(string[] input)
{
    List<string> inputList = input.ToList();
    List<List<string>> resultList = new List<List<string>>();
    List<string> finalList = new List<string>();

    foreach(string item in inputList) {

        List<string> list = new List<string>();
        int ascii = 0;
       

        for(int i = 0; i < item.Length; i++) {
            if(i == 0) {
                list.Add(item[i].ToString());
                ascii = (int)item[i];
            } else {
                if (ascii >= '0' && ascii <= '9' && item[i] >= '0' && item[i] <= '9')
                {
                    list[list.Count - 1] += item[i].ToString();
                    ascii = (int)item[i];
                }else if (char.ToUpper(item[i]) >= 'A' && char.ToUpper(item[i]) <= 'Z' && ascii >= 'A' && ascii <= 'Z')
                {
                    list[list.Count - 1] += item[i].ToString();
                    ascii = (int)char.ToUpper(item[i]);
                }else {
                    list.Add(item[i].ToString());
                    ascii = (int)char.ToUpper(item[i]);
                }
            }
        }
        resultList.Add(list);
    }

    resultList.Sort((a, b) => {
            int first = a[0].CompareTo(b[0]);

            if (first != 0)
                return first;

            return int.Parse(a[1]).CompareTo(int.Parse(b[1]));
    });

    foreach (var item in resultList)
    {
        finalList.Add(string.Join("", item));
    }

    return finalList;
    
}
List<string> Autocomplete(string input, string[] inputList, int maxResults)
{
    var results = inputList
    .Where(x => x.Contains(input, StringComparison.OrdinalIgnoreCase))
    .OrderBy(x => x.IndexOf(input, StringComparison.OrdinalIgnoreCase))
    .ToList();

    return results.Take(maxResults).ToList();
}
int FifthTest(int input)
{
    
    string input_str = input.ToString();
    List<char> inputList = input_str.ToList();
    int loopamount = (int)Math.Ceiling(inputList.Count / 2.0);
    List<char> result = new List<char>();
    
    for(int i = 0; i < loopamount; i++) {
        char max = inputList.Max();
        inputList.Remove(max);
        result.Insert(0 + i, max);
        if (inputList.Count > 0)
        {
            char min = inputList.Min();
            inputList.Remove(min);
            result.Insert(1 + i, min);
        }
    }
    
    return int.Parse(new string(result.ToArray()));

}

// bool result = FirstTest("({})");
// SecondTest(new string[] {"TH19", "SG20", "TH2"});
// SecondTest(new string[] {"TH10", "TH3Netflix", "TH7", "TH1"});
// Console.WriteLine(FifthTest(123456789));
// Console.WriteLine(Autocomplete("th", new string[] {"Mother", "Think", "Worthy","Apple","Android"}, 2));