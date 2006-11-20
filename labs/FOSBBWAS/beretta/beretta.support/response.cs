using System;
using System.Data;
using beretta.support;
using System.Collections;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for response.
	/// </summary>
	public class response
	{
		private string strInput;
		private DataSet mObjFormElements= new DataSet();
		private string[] mSubmit=new string[10];
		private string[] mFormSubmission=new string[10];
		private bool mBolContainsForm=false;

		public string input
		{
			get{return strInput;}
			set{strInput=value;}
		}

		public DataSet objFormElements
		{
			get{return mObjFormElements;}
			set{mObjFormElements=value;}
		}

		public string[] formSubmission
		{
			get{return mFormSubmission;}
			set{mFormSubmission=value;}
		}

		public string[] submit
		{
			get{return mSubmit;}
			set{mSubmit=value;}
		}

		public bool bolContainsForm
		{
			get{return mBolContainsForm;}
			set{mBolContainsForm=value;}
		}


		public response()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void analyze()
		{

			int intSubmitCount=0;
			int intElementCount=0;

			string strSubmitElements="";
			string strViewState="";
		
			DataTable objTable=new DataTable("formElements");
			DataColumn objCol1=new DataColumn("name");
			DataColumn objCol2=new DataColumn("value");
			DataColumn objCol3=new DataColumn("type");

			objTable.Columns.Add(objCol1);
			objTable.Columns.Add(objCol2);
			objTable.Columns.Add(objCol3);
			mObjFormElements.Tables.Add(objTable);
			
			mObjFormElements.AcceptChanges();

				
			System.Collections.Hashtable objHashTable;

			objHashTable=beretta.support.formParser.getInputElements(strInput);	                                                                                                                                                          
			
			if(objHashTable.Count==0)
			{
				mBolContainsForm=false;
				return;
			}
			else
			{
				mBolContainsForm=true;
			}

			IDictionaryEnumerator en = objHashTable.GetEnumerator();

			while (en.MoveNext())
			{
				formElement objFormElement=(formElement) en.Value;

				DataRow objDataRow=mObjFormElements.Tables[0].NewRow();

				objDataRow["name"]="" + objFormElement.name;
				objDataRow["value"]="" + objFormElement.value;
				objDataRow["type"]="" + objFormElement.type;

				mObjFormElements.Tables[0].Rows.Add(objDataRow);

				objDataRow=null;
				objFormElement=null;
			}
	

			//Get all the submit buttons
			foreach(DataRow objDataRow in mObjFormElements.Tables[0].Rows)
			{
				if (objDataRow["type"].ToString()=="submit")
				{
					mSubmit[intSubmitCount]="" + objDataRow["name"].ToString() + "=" + objDataRow["value"].ToString();

					intSubmitCount++;
				}
				else
				{
					if(strSubmitElements!="")
					{	
						strSubmitElements=strSubmitElements + "&";
					}
					
					if (objDataRow["name"].ToString()!="__VIEWSTATE")
					{
						strSubmitElements=strSubmitElements + beretta.support.encoding.encodeForm(objDataRow["name"].ToString()) + "=" + "%%r%%";
						intElementCount++;
					}
					else
					{
						strViewState="" + objDataRow["value"].ToString();

						strViewState=beretta.support.encoding.encodeFormElements(strViewState);

						strSubmitElements=strSubmitElements + beretta.support.encoding.encodeForm(objDataRow["name"].ToString()) + "=" + strViewState;
					}
				}

			}

			int intX=0;

			while (intX<10)
			{
				if (mSubmit[intX]=="" || mSubmit[intX]==null) break;

				mFormSubmission[intX]=strSubmitElements + "&" + mSubmit[intX];
				intX++;
			}


		}



	}
}
