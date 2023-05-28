<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="student_feedback" %>

<% 
    List<string> userData = new List<string>();
    if (Session["UserData"] != null)
    {
        userData = (List<string>)Session["UserData"];
    }
%>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    
    <title>Student</title>
    <link href="Student.css" rel="stylesheet" /> 
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
        <a>
            <img alt="User Image" src="../Stock/user.png" width="100" height="100" /></a>
        <br>
        <br>
        <a class="inactive" href="./student.aspx">Home</a>
        <a class="inactive" href="./course_reg.aspx">Course Registrations</a>
        <a class="inactive" href="./course_attendance.aspx">Attendance</a>
        <a class="inactive" href="./course_marks.aspx">Marks</a>
        <a class="inactive" href="./transcript.aspx">Transcript</a>
        <a class="active" href="./feedback_course.aspx">Course Feedback</a>


    </nav>

    <div class="box-container">

        <div class="mainPage">
            <div class="heading">
                -
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
                            
                        <input runat="server" type="radio" name="row-1" value="1"></td>

                        <td>
                            <input runat="server" type="radio" name="row-1" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="row-1" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="row-1" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="row-1" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher shows enthusiasm when teaching in class</td>
                        <td>
                            <input runat="server" type="radio" name="row-2" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="row-2" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="row-2" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="row-2" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="row-2" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher shows initiative and flexibility in teaching</td>
                        <td>
                           
                            <input runat="server" type="radio" name="row-3" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="row-3" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="row-3" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="row-3" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="row-3" value="5"></
                    </tr>
                    <tr>
                        <td>Teacher is well articulated and shows full knowledge of the subject in teaching</td>
                        <td>
                            <input runat="server" type="radio" name="row-4" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="row-4" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="row-4" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="row-4" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="row-4" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher speaks loud and clear enough to be heard by the whole class </td>
                        <td>
                            <input runat="server" type="radio" name="row-5" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="row-5" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="row-5" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="row-5" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="row-5" value="5"></
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
                            <input runat="server" type="radio" name="c1row-1" value="1"></td>

                        <td>
                            <input runat="server" type="radio" name="c1row-1" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-1" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-1" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-1" value="4"></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows commitment to teaching the class</td>
                        <td>
                            <input runat="server" type="radio" name="c1row-2" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-2" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-2" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c1row-2" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-2" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher handles criticisms and suggestions professionally</td>
                        <td>
                           
                            <input runat="server" type="radio" name="c1row-3" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-3" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-3" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-3" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="c1row-3" value="5"></
                    </tr>
                    <tr>
                        <td>Teacher comes to class on time</td>
                        <td>
                            <input runat="server" type="radio" name="c1row-4" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-4" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-4" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c1row-4" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-4" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher ends class on time</td>
                        
                        <td>
                            <input runat="server" type="radio" name="c1row-5" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-5" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-5" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c1row-5" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="c1row-5" value="5"></
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
                            <input runat="server" type="radio" name="c2row-1" value="1"></td>

                        <td>
                            <input runat="server" type="radio" name="c2row-1" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-1" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-1" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-1" value="4"></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows dynamism and enthusiasm</td>
                        <td>
                            <input runat="server" type="radio" name="c2row-2" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-2" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-2" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c2row-2" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-2" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher stimulates the critical thinking of students</td>
                        <td>
                           
                            <input runat="server" type="radio" name="c2row-3" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-3" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-3" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-3" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="c2row-3" value="5"></
                    </tr>
                    <tr>
                        <td>Teacher has organized the lesson conducive for easy understanding of students</td>
                        <td>
                            <input runat="server" type="radio" name="c2row-4" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-4" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-4" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c2row-4" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-4" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher stimulates the critical thinking of students</td>
                        
                        <td>
                            <input runat="server" type="radio" name="c2row-5" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-5" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-5" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c2row-5" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="c2row-5" value="5"></
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
                            <input runat="server" type="radio" name="c3row-1" value="1"></td>

                        <td>
                            <input runat="server" type="radio" name="c3row-1" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-1" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-1" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-1" value="4"></td>
                       
                    </tr>
                    <tr>
                        <td>Teacher shows equal respect to various cultural backgrounds, individuals, religion, and race</td>
                        <td>
                            <input runat="server" type="radio" name="c3row-2" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-2" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-2" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c3row-2" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-2" value="5"></td>
                    </tr>
                    <tr>
                        <td>Teacher finds the students strengths as basis for growth and weaknesses for opportunities for improvement</td>
                        <td>
                           
                            <input runat="server" type="radio" name="c3row-3" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-3" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-3" value="3"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-3" value="4"></td>
                        <td>    
                            <input runat="server" type="radio" name="c3row-3" value="5"></
                    </tr>
                    <tr>
                        <td>Teacher understands the weakness of a student and helps in the student's improvement</td>
                        <td>
                            <input runat="server" type="radio" name="c3row-4" value="1"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-4" value="2"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-4" value="3"></td>
                            <td>
                            <input runat="server" type="radio" name="c3row-4" value="4"></td>
                        <td>
                            <input runat="server" type="radio" name="c3row-4" value="5"></td>
                    </tr>
                </table>
            </div>
                <br />
        <h4> Comment </h4>
             
		<textarea runat="server" id="comments" name="comments" rows="5" cols="80" ></textarea>
         <asp:Button CssClass="btn btn-success" style="background-color:green;margin-left:40%;" runat="server" Text="Submit" OnClick="Unnamed1_Click"></asp:Button>

            </div> 
                </form>

           </div>    
    </div>
</body>
</html>