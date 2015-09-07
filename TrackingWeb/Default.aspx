<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="UTF-8">
    <title>Tracking Service</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="renderer" content="webkit">
    <link rel="stylesheet" href="App_Themes/Bootstrap/css/bootstrap.min.css">
    <script src="App_Themes/JQuery/jquery-1.11.2.min.js"></script>
    <script src="App_Themes/Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function ShowMsg(result) {
            var strs = result.split('#');
            var result = "";
            var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            if (strs.length > 1) {
                result = "TrackingNum" + space + strs[0] + "<br/>";
                result = result + "PONum" + space + strs[1] + "<br/>";
                result = result + "ReferenceNumber" + space + strs[2] + "<br/>";
                result = result + "BillOfLading" + space + strs[3] + "<br/>";
                result = result + "Status" + space + strs[4] + "<br/>";
                result = result + "StatusTimeStamp" + space + strs[5] + "<br/>";
                result = result + "imageURL" + space + strs[6] + "<br/>";
                result = result + "DeliverByDate" + space + strs[7] + "<br/>";
                result = result + "PodTimeStamp" + space + strs[8] + "<br/>";
                result = result + "PODSig" + space + strs[9] + "<br/>";
                result = result + "TrackingNumberKey" + space + strs[10] + "<br/>";
                result = result + "OriginParty" + space + strs[11] + "<br/>";
                result = result + "DestinationParty" + space + strs[12] + "<br/>";
            } else {
                result = strs[0];
            }
            $("#wellResult").html(result);
        }
        function GetReturnValue() { 
            var txtCustomerGroup = document.getElementById("txtCustomerGroup").value;
            var txtUserLoginName = document.getElementById("txtUserLoginName").value;
            var txtUserPwd = document.getElementById("txtUserPwd").value;
            var txtRefType = document.getElementById("drpRefType").value;
            var txtRefValue = document.getElementById("txtRefValue").value;
            var arg = txtCustomerGroup + "#" + txtUserLoginName + "#" + txtUserPwd + "#" + txtRefType + "#" + txtRefValue;
            CallServer(arg, "");
        }
    </script>
</head>
<body>
    <div class="container">
        <div style="margin-top:20px;"></div>
        <form id="form1" class="form-horizontal" runat="server">
            <div class="col-xs-8">
                <div class="form-group form-group-sm">
                    <label for="txtCustomerGroup" id="lblCustomerGroup" class="col-xs-3 control-label">Customer Group</label>
                    <div class="col-xs-9">
                        <asp:TextBox id="txtCustomerGroup" runat="server" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtUserLoginName" id="lblUserLoginName" class="col-xs-3 control-label">User Login Name</label>
                    <div class="col-xs-9">
                        <asp:TextBox id="txtUserLoginName" runat="server" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtUserPwd" id="lblUserPwd" class="col-xs-3 control-label">User Pwd</label>
                    <div class="col-xs-9">
                        <asp:TextBox id="txtUserPwd" runat="server" TextMode="Password" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="drpRefType " id="lblRefType" class="col-xs-3 control-label">Ref Type</label>
                    <div class="col-xs-9">
                        <asp:DropDownList id="drpRefType" runat="server" CssClass="form-control">
                            <asp:ListItem>T</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>R</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtRefValue" id="lblRefValue" class="col-xs-3 control-label">Ref Value</label>
                    <div class="col-xs-9">
                        <asp:TextBox id="txtRefValue" runat="server" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <div class="col-xs-6 col-xs-offset-3">
                        <div class="col-xs-4">
                            <input type="button" id="btnGetResult" runat="server" class="btn btn-default btn-sm btn-blue" value="Get Result" onclick="GetReturnValue();return false;" />
                        </div>
                    </div>
                </div>
                <div id="wellResult" class="well"></div>
            </div>
        </form>
    </div>
</body>
</html>
