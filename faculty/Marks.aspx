<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Marks.aspx.cs" Inherits="Marks" %>

<% 
    List<string> userData = new List<string>();
    if (Session["UserData"] != null)
    {
        userData = (List<string>)Session["UserData"];
    }
%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <title>Instructor Page</title>
    <link href="/StyleSheet.css" rel="stylesheet" />
    <style>
        label {
            display: block;
            margin-bottom: 10px;
        }

        input[type="text"] {
            width: 200px;
            margin-left: 10px;
        }

        select {
            width: 200px;
            margin-left: 10px;
        }

        table {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
        }

            table td,
            table th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            table th {
                text-align: left;
            }

        .button-container {
            margin-top: 20px;
            text-align: center;
        }

        .button {
            background-color: #4caf50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

            .button:hover {
                background-color: #3e8e41;
            }
    </style>
</head>
<body>

    <nav class="nav">
        <br />
        <a>
            <img src="/'Stock/user.png" alt="My Image" width="100" height="100" /></a>
        <br />
        <br />
        <a class="inactive" href="/faculty/Instructor.aspx">Home</a>
        <a class="inactive" href="/faculty/CourseAttendance.aspx">Attendance</a>
        <a class="active" href="/faculty/CourseMarks.aspx">Marks</a>
    </nav>
    <div class="container">

        <div class="heading">
            <h3>Welcome to Marks</h3>
        </div>
        <form id="form2" runat="server">
            <h2>Set Distribution</h2>
            <div>
                <label for="course">
                    Course: <%= Request.QueryString["CID"] %>
                </label>
                <br />
                <label for="section">
                    Section: <%= Request.QueryString["SID"] %>
                </label>
                <br />
                <label for="note">
                    Note: Click Save Button to Save Changes !
                </label>
                <br />
                <label for="evalType">
                    Evaluation Type:
                </label>
                <asp:DropDownList ID="ddlEvalType" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Extra" Value="dummy"></asp:ListItem>
                    <asp:ListItem Text="Dummy" Value="dummy"></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:GridView ID="GridViewEvaluations" runat="server" CssClass="gridview" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Assignment">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("AssignmentWeight") %>' CssClass="form-control" Type="Number" min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quiz">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("QuizzesWeight") %>' CssClass="form-control" Type="Number" min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sessional 1">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Mid1Weight") %>' CssClass="form-control" Type="Number" min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sessional 2">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Mid2Weight") %>' CssClass="form-control" Type="Number" min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FinalWeight") %>' CssClass="form-control" Type="Number" min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Range">
                            <ItemTemplate>
                                <label>Range: 0 - 100 </label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


                <label id="lblSum"></label>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnLogin" OnClick="btnSave_Click" Enabled="True" />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>

            <br />
            <br />
            <br />
            <div>
                <h2>Evaluation Form</h2>
                <asp:GridView ID="GridViewMarks" runat="server" CssClass="gridview" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Roll Number">
                            <ItemTemplate>
                                <asp:TextBox ID="sid" runat="server" Text='<%# Eval("StudentID") %>'></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assignment">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAssignment" runat="server" TextMode="Number" Text='<%# Eval("AssignmentWeight") %>' min="0" max='<%#maxA%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sessional 1">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMid1Marks" runat="server" TextMode="Number" Text='<%# Eval("Mid1Weight") %>' min="0" max='<%#maxM1%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sessional 2">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMid2Marks" runat="server" TextMode="Number" Text='<%# Eval("Mid2Weight") %>' min="0" max='<%#maxM2%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quiz">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQuizMarks" runat="server" TextMode="Number" Text='<%# Eval("QuizzesWeight") %>' min="0" max='<%#maxQ%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final Exam">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFinalExamMarks" runat="server" TextMode="Number" Text='<%# Eval("FinalWeight") %>' min="0" max='<%#maxF%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Marks">
                            <ItemTemplate>
                                <asp:TextBox ID="lblTotalMarks" runat="server" TextMode="Number" Text='<%# calculate_total(Eval("QuizzesWeight").ToString(),Eval("AssignmentWeight").ToString(),Eval("Mid1Weight").ToString(),Eval("Mid2Weight").ToString(),Eval("FinalWeight").ToString()) %>' min="0" max="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnLogin" runat="server" Text="Save" OnClick="btnSave_Click1" Enabled="True" />
            </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewStudents"  CssClass="gridview" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ARN" HeaderText="Student ID" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
        </form>
    </div>
</body>
</html>
