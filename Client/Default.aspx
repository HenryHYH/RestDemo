<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client.Default" %>

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
    <div>
        <table>
            <thead>
                <tr>
                    <th>
                        ID
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Operation
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptAccount" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("Id") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" OnClick="lbtnEdit_Click"
                                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" OnClick="lbtnDelete_Click"
                                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    ID
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
