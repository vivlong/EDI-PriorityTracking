﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrackingService;

public partial class _Default : System.Web.UI.Page, ICallbackEventHandler
{
    private string _callbackResult = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        string reference = Page.ClientScript.GetCallbackEventReference(this, "arg", "ShowMsg", "context");  
        string regCallbakeScript = "function CallServer(arg,context){" + reference + "}";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", regCallbakeScript, true);
    }
 
    public void RaiseCallbackEvent(string eventArgument)
    {
        string strResult = "";
        string[] strs = eventArgument.Split('#');
        TrackingQueryServer tqs = new TrackingQueryServer();
        string strGroupName = strs[0];
        string strUserLoginName = strs[1];
        string strUserPwd = strs[2];
        string strRefType = strs[3];
        string strRefValue = strs[4];
        string strXML = tqs.getOrderStatus(strGroupName, strUserLoginName, strUserPwd, strRefType, strRefValue);
        //string strXML = "<results name=\"TrackingService.TrackingQueryServer.getOrderStatus\" version=\"3.1c\" origin=\"Priority Solutions International\"><Shipment><TrackingNum>1234567</TrackingNum><ReferenceNumber>TRACK-123</ReferenceNumber><StatusTimeStamp><month>4</month><date>14</date><year>2015</year><hour>16</hour><minute>57</minute><second>18</second></StatusTimeStamp><Status>POD: Delivered with Signature</Status><DeliverByDate><month>4</month><date>14</date><year>2015</year><hour>0</hour><minute>0</minute><second>0</second></DeliverByDate><PodTimeStamp><month>4</month><date>9</date><year>2015</year><hour>0</hour><minute>0</minute><second>0</second></PodTimeStamp><PODSig>TRACY</PODSig><TrackingNumberKey>1234567</TrackingNumberKey><OriginParty>ABC COMPANY</OriginParty><DestinationParty>ZOO COMPANY</DestinationParty></Shipment></results>";
        try
        {
            XMLParser xmlParser = new XMLParser();
            XMLNode xn = xmlParser.Parse(strXML);
            XMLNode temp = xn.GetNode("results>0>Shipment>0");
            if (temp != null)
            {
                string TrackingNum = " ";
                if (temp.GetNode("TrackingNum>0") != null)
                {
                    TrackingNum = temp.GetValue("TrackingNum>0>_text");
                }
                string PONum = " ";
                if (temp.GetNode("PONum>0") != null)
                {
                    PONum = temp.GetValue("PONum>0>_text");
                }
                string ReferenceNumber = " ";
                if (temp.GetNode("ReferenceNumber>0") != null)
                {
                    ReferenceNumber = temp.GetValue("ReferenceNumber>0>_text");
                }
                string BillOfLading = " ";
                if (temp.GetNode("BillOfLading>0") != null)
                {
                    BillOfLading = temp.GetValue("BillOfLading>0>_text");
                }
                string Status = temp.GetValue("Status>0>_text");
                DateTime dt;
                string StatusTimeStamp = " ";
                if (temp.GetNode("StatusTimeStamp>0") != null)
                {
                    string StatusTimeStampMonth = temp.GetValue("StatusTimeStamp>0>month>0>_text");
                    string StatusTimeStampDate = temp.GetValue("StatusTimeStamp>0>date>0>_text");
                    string StatusTimeStampYear = temp.GetValue("StatusTimeStamp>0>year>0>_text");
                    string StatusTimeStampHour = temp.GetValue("StatusTimeStamp>0>hour>0>_text");
                    string StatusTimeStampMinute = temp.GetValue("StatusTimeStamp>0>minute>0>_text");
                    string StatusTimeStampSecond = temp.GetValue("StatusTimeStamp>0>second>0>_text");
                    dt = new DateTime(int.Parse(StatusTimeStampYear), int.Parse(StatusTimeStampMonth), int.Parse(StatusTimeStampDate), int.Parse(StatusTimeStampHour), int.Parse(StatusTimeStampMinute), int.Parse(StatusTimeStampSecond));
                    StatusTimeStamp = dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string imageURL = " ";
                if (temp.GetNode("imageURL>0") != null)
                {
                    imageURL = temp.GetValue("imageURL>0>_text");
                }
                string DeliverByDate = " ";
                if (temp.GetNode("DeliverByDate>0") != null)
                {
                    string DeliverByDateMonth = temp.GetValue("DeliverByDate>0>month>0>_text");
                    string DeliverByDateDate = temp.GetValue("DeliverByDate>0>date>0>_text");
                    string DeliverByDateYear = temp.GetValue("DeliverByDate>0>year>0>_text");
                    string DeliverByDateHour = temp.GetValue("DeliverByDate>0>hour>0>_text");
                    string DeliverByDateMinute = temp.GetValue("DeliverByDate>0>minute>0>_text");
                    string DeliverByDateSecond = temp.GetValue("DeliverByDate>0>second>0>_text");
                    dt = new DateTime(int.Parse(DeliverByDateYear), int.Parse(DeliverByDateMonth), int.Parse(DeliverByDateDate), int.Parse(DeliverByDateHour), int.Parse(DeliverByDateMinute), int.Parse(DeliverByDateSecond));
                    DeliverByDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string PodTimeStamp = " ";
                if (temp.GetNode("PodTimeStamp>0") != null)
                {
                    string PodTimeStampMonth = temp.GetValue("PodTimeStamp>0>month>0>_text");
                    string PodTimeStampDate = temp.GetValue("PodTimeStamp>0>date>0>_text");
                    string PodTimeStampYear = temp.GetValue("PodTimeStamp>0>year>0>_text");
                    string PodTimeStampHour = temp.GetValue("PodTimeStamp>0>hour>0>_text");
                    string PodTimeStampMinute = temp.GetValue("PodTimeStamp>0>minute>0>_text");
                    string PodTimeStampSecond = temp.GetValue("PodTimeStamp>0>second>0>_text");
                    dt = new DateTime(int.Parse(PodTimeStampYear), int.Parse(PodTimeStampMonth), int.Parse(PodTimeStampDate), int.Parse(PodTimeStampHour), int.Parse(PodTimeStampMinute), int.Parse(PodTimeStampSecond));
                    PodTimeStamp = dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string PODSig = " ";
                if (temp.GetNode("PODSig>0") != null)
                {
                    PODSig = temp.GetValue("PODSig>0>_text");
                }
                string TrackingNumberKey = " ";
                if (temp.GetNode("TrackingNumberKey>0") != null)
                {
                    TrackingNumberKey = temp.GetValue("TrackingNumberKey>0>_text");
                }
                string OriginParty = " ";
                if (temp.GetNode("OriginParty>0") != null)
                {
                    OriginParty = temp.GetValue("OriginParty>0>_text");
                }
                string DestinationParty = " ";
                if (temp.GetNode("DestinationParty>0") != null)
                {
                    DestinationParty = temp.GetValue("DestinationParty>0>_text");
                }
                strResult = TrackingNum + "#" + PONum + "#" + ReferenceNumber + "#" + BillOfLading + "#" + Status + "#" + StatusTimeStamp + "#" + imageURL + "#" + DeliverByDate + "#" + PodTimeStamp + "#" + PODSig + "#" + TrackingNumberKey + "#" + OriginParty + "#" + DestinationParty;
            }
            else
            {
                strResult = xn.GetValue("results>0>Error>0>Explanation>0>_text");
            }
        }
        catch (Exception ex) { strResult = ex.Message; }
        _callbackResult = strResult;
    }

    public string GetCallbackResult()
    {
        return _callbackResult;
    }
}