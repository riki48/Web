namespace MyNamespace
{   
    class Program
    {
       public static Main(string s)
       {
           string output = "";
           string temp = s[0]
           int counter = 1;
           for (int i = 1; i < s.length; i++)
           {
              if(temp!=s[i])
              {
                  output+=counter+temp;
                  counter=1;
              }
              else counter++;
              if(i+1<s.length){
                  output+=counter+temp;
              }
           }
           System.Console.WriteLine(output);

       } 
    }
}