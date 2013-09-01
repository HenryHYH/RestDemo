<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="Client.Ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body { font: 14px Arial; }
        table, td, th { border: solid 1px #ccc; }
        td, th { padding: 10px; }
        table { border-collapse: collapse; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tbAccounts">
        <thead>
            <tr>
                <th>
                    ID
                </th>
                <th>
                    Name
                </th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsrender.min.js"></script>
    <script type="text/x-jsrender" id="tmplAccount">
    {{for #data}}
        <tr>
            <td>{{:Id}}</td>
            <td>{{:Name}}</td>
        </tr>
    {{/for}}
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                url: "http://127.0.0.1:6001/Account",
                type: "GET",
                dataType: "json",
                success: function (msg) {
                    var data = eval(msg);
                    var html = $("#tmplAccount").render(data);
                    $("#tbAccounts tbody").append(html);
                },
                error: function (xhr) {
                    alert("error");
                }
            });
        });
    </script>
    </form>
</body>
</html>
