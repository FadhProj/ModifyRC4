using System;
class StreamRC4{

    private int[] arrK = new int[256];
    

    private int[] arrS = new int[256];

    public StreamRC4(string key)
    {
        //Console.WriteLine(key);
        for (int i = 0; i < 256; i++)
        {
            arrK[i] = key[i % key.Length];
            arrS[i] = i;
        }
    }


    public void swap(int i , int j){
        int tmp = arrS[i];
        arrS[i] = arrS[j];
        arrS[j] = tmp;
    }

    public void keySchedulingAlgorithm(){
        int j = 0;
        for( int i = 0 ;i < 256;i++)
        {
            j= (j + arrS[i] + arrK[i]+23) % 256;
            swap(i,j);
        }

    }

    public void pseudoRandomGenaratorAlgorithm(ref string message){
        int i = 0;
        int j = 0;
        string newM="";
        int byteChiper;
        foreach (char item in message)
        {
            i = (j + 1) % 256;
            j = (j + arrS[i]) % 256;
            swap(i,j);
            byteChiper = arrS[(arrS[i] + arrS[j]) % 256];
            //Console.Write(item);
            //Console.Write(" ");
            //Console.Write(byteChiper ^ System.Convert.ToInt64(item));
            //Console.Write(" ");
            newM += System.Convert.ToChar(byteChiper ^ System.Convert.ToInt64(item));
            //newM += " "      ; 
            //Console.Write(System.Convert.ToChar(byteChiper ^ System.Convert.ToInt64(item)));  
            //Console.WriteLine(" ");   
        }
        
        message = newM;
    }

    public void encrypt(ref string message)
    {
        keySchedulingAlgorithm();
        Console.WriteLine("Message : " + message);
        pseudoRandomGenaratorAlgorithm(ref message);
        Console.WriteLine("Encrypted Message : "+ message);
    }

    public void Decrypt(ref string message)
    {
        keySchedulingAlgorithm();
        Console.WriteLine("Message : " + message);
        pseudoRandomGenaratorAlgorithm(ref message);
        Console.WriteLine("Decrypted Message : " + message);
    }

    

}