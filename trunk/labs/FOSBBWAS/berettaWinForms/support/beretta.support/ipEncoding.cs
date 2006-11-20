using System;

namespace beretta.support
{
	/// <summary>
	/// Summary description for ipEncoding.
	/// </summary>
	public class ipEncoding
	{
		public ipEncoding()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static string ipToDword(string strInput)
		{
			string[] strIp=strInput.Split('.');
			Int64 intTmp=0;

			
			intTmp=(System.Convert.ToInt32(strIp[0]) * 256) + System.Convert.ToInt32(strIp[1]);
			intTmp=(intTmp * 256) + System.Convert.ToInt32(strIp[2]);
			intTmp=(intTmp * 256) + System.Convert.ToInt32(strIp[3]);
			
			return intTmp.ToString();
		
		}

		public static string ipToOctal(string strInput)
		{
			
			string[] n;
			

			n=strInput.Split('.'); 

			for(int i=0;i<4;i++)
			{ 
				n[i]=(n[i]);
				
				
				int one=System.Convert.ToInt32(n[i])/64; 
				int t=System.Convert.ToInt32(n[i])%64; 
				int two=(t/8);
				int three=System.Convert.ToInt32(n[i])%8; 
				n[i]='0'+ one.ToString() + two.ToString() + three.ToString(); 
			} 
			
			string octip=n[0] + "." + n[1] + "." + n[2] + "." + n[3];
			return octip;
  
		}

		public static string ipToHex(string ip)
		{ 
			string[] n;
			
			n=ip.Split('.'); 

			for(int i=0;i<4;i++) 
			{ 
				if(System.Convert.ToInt32(n[i])>255)
				{
					return "";
				}

				string two=numlet(System.Convert.ToString(System.Convert.ToInt32(n[i])%16)); 
				string one=numlet(System.Convert.ToString(System.Convert.ToInt32(n[i])/16));

				n[i]="0x" + one.ToString() + two.ToString();
			} 

			string hexip=n[0].ToString() + "." + n[1].ToString() + "." + n[2].ToString() + "." + n[3].ToString();
			
			return hexip; 
		}

		public static string numlet(string num)
		{ 
			if(num=="10"){return "a";} 
			if(num=="11"){return "b";}
			if(num=="12"){return "c";} 
			if(num=="13"){return "d";} 
			if(num=="14"){return "e";}
			if(num=="15"){return "f";} 
			return num;
		} 
		

	}
}
