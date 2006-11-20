using System;
using System.Data;
using System.Xml;


namespace berettaWinForms.classes
{
	/// <summary>
	/// Summary description for loadXml.
	/// </summary>
	public class loadXml
	{
		public loadXml()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet loadSignatures(string strPath) 
		{
			string strId="";
			string strSignatureName="";
			string strSignatureValue="";
			string strSignatureOperator="";
			string strSignatureDescription="";
			string strSignatureMessage="";
			string strSignatureMessageType="";
			string strSignatureType="";


			DataSet objDataSet=new DataSet();
			DataTable objTable=new DataTable();
			DataColumn objCol0=new DataColumn();
			DataColumn objCol1=new DataColumn();
			DataColumn objCol2=new DataColumn();
			DataColumn objCol3=new DataColumn();
			DataColumn objCol4=new DataColumn();
			DataColumn objCol5=new DataColumn();
			DataColumn objCol6=new DataColumn();
			DataColumn objCol7=new DataColumn();


			objCol0.ColumnName="id";
			objCol1.ColumnName="signatureName";
			objCol2.ColumnName="signatureValue";
			objCol3.ColumnName="signatureOperator";
			objCol4.ColumnName="signatureDescription";
			objCol5.ColumnName="signatureMessage";
			objCol6.ColumnName="signatureMessageType";
			objCol7.ColumnName="signatureType";


			objTable.Columns.Add(objCol0);
			objTable.Columns.Add(objCol1);
			objTable.Columns.Add(objCol2);
			objTable.Columns.Add(objCol3);
			objTable.Columns.Add(objCol4);
			objTable.Columns.Add(objCol5);
			objTable.Columns.Add(objCol6);
			objTable.Columns.Add(objCol7);

			objDataSet.Tables.Add(objTable);


			System.Xml.XmlDocument objXmlDoc=new XmlDocument();

			System.Xml.XmlNodeList objXmlNodeList;

			objXmlDoc.Load(strPath);


			objXmlNodeList=objXmlDoc.SelectNodes("signatures/*");

			foreach(System.Xml.XmlNode objXmlNode in objXmlNodeList)
			{


				foreach(System.Xml.XmlNode objChildNode in objXmlNode.ChildNodes)
				{
					

					switch(objChildNode.Name)
					{
						case "id" : strId=objChildNode.InnerText;
							break;
						case "signatureName" : strSignatureName=objChildNode.InnerText;
							break;
						case "signatureValue" : strSignatureValue=objChildNode.InnerText;
							break;
						case "signatureOperator" : strSignatureOperator=objChildNode.InnerText;
							break;
						case "signatureDescription" : strSignatureDescription=objChildNode.InnerText;
							break;
						case "signatureMessage" : strSignatureMessage=objChildNode.InnerText;
							break;
						case "signatureMessageType" : strSignatureMessageType=objChildNode.InnerText;
							break;
						case "signatureType" : strSignatureType=objChildNode.InnerText;
							break;
					
					}

				}

				DataRow objDataRow;
				objDataRow=objDataSet.Tables[0].NewRow();

				objDataRow["id"]="" + strId;
				objDataRow["signatureName"]="" + strSignatureName;
				objDataRow["signatureValue"]="" + strSignatureValue;
				objDataRow["signatureOperator"]="" + strSignatureOperator;
				objDataRow["signatureDescription"]="" + strSignatureDescription;
				objDataRow["signatureMessage"]="" + strSignatureMessage;
				objDataRow["signatureMessageType"]="" + strSignatureMessageType;
				objDataRow["signatureType"]="" + strSignatureType;

				objDataSet.Tables[0].Rows.Add(objDataRow);

				objDataRow=null;

				
			}


			objDataSet.AcceptChanges();

			return objDataSet;
		}



		public DataSet loadPayloads(string strPath) 
		{
			string strId="";
			string strPayloadName="";
			string strPayloadData="";
			string strDescription="";
			string strType="";
	
		
			DataSet objDataSet=new DataSet();
			DataTable objTable=new DataTable();

			DataColumn objCol0=new DataColumn();
			DataColumn objCol1=new DataColumn();
			DataColumn objCol2=new DataColumn();
			DataColumn objCol3=new DataColumn();
			DataColumn objCol4=new DataColumn();


			objCol0.ColumnName="id";
			objCol1.ColumnName="payloadName";
			objCol2.ColumnName="payloadData";
			objCol3.ColumnName="description";
			objCol4.ColumnName="type";
		
			objTable.Columns.Add(objCol0);
			objTable.Columns.Add(objCol1);
			objTable.Columns.Add(objCol2);
			objTable.Columns.Add(objCol3);
			objTable.Columns.Add(objCol4);
	
			objDataSet.Tables.Add(objTable);


			System.Xml.XmlDocument objXmlDoc=new XmlDocument();

			System.Xml.XmlNodeList objXmlNodeList;

			objXmlDoc.Load(strPath);


			objXmlNodeList=objXmlDoc.SelectNodes("payloads/*");

			foreach(System.Xml.XmlNode objXmlNode in objXmlNodeList)
			{


				foreach(System.Xml.XmlNode objChildNode in objXmlNode.ChildNodes)
				{
					

					switch(objChildNode.Name)
					{
						case "id" : strId=objChildNode.InnerText;
							break;
						case "payloadName" : strPayloadName=objChildNode.InnerText;
							break;
						case "payloadData" : strPayloadData=objChildNode.InnerText;
							break;
						case "description" : strDescription=objChildNode.InnerText;
							break;
						case "type" : strType=objChildNode.InnerText;
							break;
							
					}

				}

				DataRow objDataRow;
				objDataRow=objDataSet.Tables[0].NewRow();

				objDataRow["id"]="" + strId;
				objDataRow["payloadName"]="" + strPayloadName;
				objDataRow["payloadData"]="" + strPayloadData;
				objDataRow["description"]="" + strDescription;
				objDataRow["type"]="" + strType;
			
				objDataSet.Tables[0].Rows.Add(objDataRow);

				objDataRow=null;

				
			}


			objDataSet.AcceptChanges();

			return objDataSet;
		}




	}
}
