<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedbackResponses.aspx.cs" Inherits="feedbackResponses" %>

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
        table {
            border-collapse: collapse;    
        }
        td, th {
            border: 1px solid #ccc;
            padding: 10px;
        }
        th:empty {
            border: 0;
        }
	</style>

</head>
<body>

    <nav class="nav">
        <br />
        <a>
            <img src="/Stock/user.png" alt="My Image" width="100" height="100" /></a>
        <br />
        <br />
        <a class="active" href="/faculty/Instructor.aspx">Home</a>
        <a class="inactive" href="/faculty/CourseAttendance.aspx">Attendance</a>
        <a class="inactive" href="/faculty/CourseMarks.aspx">Marks</a>
        <a class="inactive" href="/faculty/courseFeedback.aspx">Course Feedback</a>
    </nav>

    <div class="container">

        <div class="mainPage">
            <div class="heading">
        <h3>Course Feedback</h3>
            </div>
                <form id="feedbackform" runat="server">

            <br />
            <div class="box">
                
            <br />
            <h4>Appearance and Personal Presentation</h4>
            <div>
                <table>


                    <tr>
                        <th></th>
                        <th>1</th>
                        <th>2</th>
                        <th>3</th>
                        <th>4</th>
                        <th>5</th>

                    </tr>
                    <tr>
                        <td>Teacher attends class in a well presentable manner</td>
                        <td>
                            <asp:Label ID="o1c1" runat="server" Text="1 choose" visible="true"></asp:Label>   
                        </td>

                        <td>
                            <asp:Label ID="o1c2" runat="server" Text="1 chooses" visible="true"></asp:Label>   
                        </td>
                        <td>
                            <asp:Label ID="o1c3" runat="server" Text="1 chooses" visible="true"></asp:Label>   
                        </td>
                        <td>
                            <asp:Label ID="o1c4" runat="server" Text="2 chooses" visible="true"></asp:Label>   
                        </td>
                        <td>
                            <asp:Label ID="o1c5" runat="server" Text="1 chooses" visible="true"></asp:Label>   
                        </td>
                    </tr>
                    <tr>
                        <td>Teacher shows enthusiasm when teaching in class</td>
                        <td>
                            <asp:Label ID="o2c1" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o2c2" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o2c3" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                            <td>
                            <asp:Label ID="o2c4" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o2c5" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                    </tr>
                    <tr>
                        <td>Teacher shows initiative and flexibility in teaching</td>
                        <td>
                           
                            <asp:Label ID="o3c1" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o3c2" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o3c3" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o3c4" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>    
                            <asp:Label ID="o3c5" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                    </tr>
                    <tr>
                        <td>Teacher is well articulated and shows full knowledge of the subject in teaching</td>
                        <td>
                            <asp:Label ID="o4c1" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o4c2" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o4c3" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                            <td>
                            <asp:Label ID="o4c4" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o4c5" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                    </tr>
                    <tr>
                        <td>Teacher speaks loud and clear enough to be heard by the whole class </td>
                        <td>
                            <asp:Label ID="o5c1" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o5c2" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o5c3" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>
                            <asp:Label ID="o5c4" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                        <td>    
                            <asp:Label ID="o5c5" runat="server" Text="1 chooses" visible="true"></asp:Label>   </td>
                    </tr>
                </table>
                <br/>
                            <h4> Professional Practices </h4>

                <table>


                    <tr>
                        <th></th>
                        <th>1</th>
                        <th>2</th>
                        <th>3</th>
                        <th>4</th>
                        <th>5</th>

                    </tr>
                    <tr>
                        <td>Teacher shows professionalism in class </td>
                        <td>
                            <asp:Label ID="o6c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>

                        <td>
                            <asp:Label ID="o6c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o6c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o6c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                           <asp:Label ID="o6c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows commitment to teaching the class</td>
                        <td>
                            <asp:Label ID="o7c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o7c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o7c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o7c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o7c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher handles criticisms and suggestions professionally</td>
                        <td>
                           
                            <asp:Label ID="o8c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o8c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o8c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o8c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>    
                            <asp:Label ID="o8c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher comes to class on time</td>
                        <td>
                            <asp:Label ID="o9c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o9c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o9c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o9c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o9c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher ends class on time</td>
                        
                        <td>
                           <asp:Label ID="o10c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o10c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o10c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o10c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>    
                            <asp:Label ID="o10c5" runat="server" Text="1 chooses" visible="true"></asp:Label></
                    </tr>
                </table>


                <br/>
                            <h4> Teaching Methods</h4>

                <table>


                    <tr>
                        <th></th>
                        <th>1</th>
                        <th>2</th>
                        <th>3</th>
                        <th>4</th>
                        <th>5</th>

                    </tr>
                    <tr>
                        <td>Teacher shows well rounded knowledge over the subject matter</td>
                        <td>
                            <asp:Label ID="o11c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>

                        <td>
                            <asp:Label ID="o11c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o11c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                           <asp:Label ID="o11c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                           <asp:Label ID="o11c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows dynamism and enthusiasm</td>
                        <td>
                            <asp:Label ID="o12c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o12c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o12c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o12c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                           <asp:Label ID="o12c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher stimulates the critical thinking of students</td>
                        <td>
                           
                            <asp:Label ID="o13c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o13c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o13c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o13c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>    
                            <asp:Label ID="o13c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher has organized the lesson conducive for easy understanding of students</td>
                        <td>
                            <asp:Label ID="o14c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o14c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o14c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o14c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o14c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher stimulates the critical thinking of students</td>
                        
                        <td>
                            <asp:Label ID="o15c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o15c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o15c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o15c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>    
                            <asp:Label ID="o15c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                </table>
                

                <br/>
                            <h4> Disposition Towards Students </h4>

                <table>


                    <tr>
                        <th></th>
                        <th>1</th>
                        <th>2</th>
                        <th>3</th>
                        <th>4</th>
                        <th>5</th>

                    </tr>
                    <tr>
                        <td>Teacher believes that students can learn from the class</td>
                        <td>
                            <asp:Label ID="o16c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>

                        <td>
                           <asp:Label ID="o16c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o16c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o16c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o16c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows equal respect to various cultural backgrounds, individuals, religion, and race</td>
                        <td>
                            <asp:Label ID="o17c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o17c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o17c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o17c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o17c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher finds the students strengths as basis for growth and weaknesses for opportunities for improvement</td>
                        <td>
                           
                            <asp:Label ID="o18c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o18c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o18c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o18c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>    
                            <asp:Label ID="o18c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Teacher understands the weakness of a student and helps in the student's improvement</td>
                        <td>
                            <asp:Label ID="o19c1" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o19c2" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o19c3" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                            <td>
                            <asp:Label ID="o19c4" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                        <td>
                            <asp:Label ID="o19c5" runat="server" Text="1 chooses" visible="true"></asp:Label></td>
                    </tr>
                </table>
            </div>
                <br />
        <h4> Comments </h4>
            <asp:GridView ID="showComments" runat="server" CssClass="table table-condensed table-hover">
             </asp:GridView>
            </div> 
                </form>

           </div>    
    </div>
</body>
</html>
