public static class ADOAPIHandler
{
    public static void GetWorkItemDetails(List<string> bugIds)
    {
        /*foreach(var bugId in bugIds)
        {
            try
            {
                if (!string.IsNullOrEmpty(bugId))
                {
                    string workitem = string.Format(, bugId); //get the bug info details
                    string pipelineTimeline = await QueryBuilderHelper.GetUriResult(personalaccesstoken, workitem.ToString());
                    dynamic response = JsonConvert.DeserializeObject(pipelineTimeline);
                    WorkItemRoot myDeserializedClass = JsonConvert.DeserializeObject<WorkItemRoot>(response.ToString());//bug item
                    var workitemField = myDeserializedClass.fields; //
                    
                    if (workitemField != null)
                    {
                        if (workitemField.SystemAssignedTo.displayName != null)
                        {
                            if (workitemField.One_customHitCount != null)
                            {
                                try{
                                    bugOwner = workitemField.SystemAssignedTo.displayName;
                                    bugState = workitemField.SystemState;
                                    bugTitle = workitemField.SystemTitle;
                                    bugHitCount = workitemField.One_customHitCount;
                                    if (!bugInfoDict.ContainsKey(bugId))
                                    {
                                        bugInfoDict.Add(pipelineError.BuildId ,new BugInformation(bugId, bugTitle, bugState, bugOwner, bugHitCount));
                                        //Console.WriteLine(bugId + " " + bugTitle + " " + bugState + " " + bugOwner + " " + bugHitCount);
                                    }
                                }catch(Exception ex){}
                            }          
                        }  
                    } 
                }
                else
                {
                    bugId = "No bug id found!";
                    //Console.WriteLine("BugID is null or empty");
                }

                bugOwner = string.Empty;
                bugState = string.Empty;
                bugTitle = string.Empty;
                bugHitCount = string.Empty;
                bugId = string.Empty;
            }
            catch(Exception ex){}
            //catch(Exception ex){Console.WriteLine("BuildId " + pipelineError.BuildId + " outer catch " +ex.ToString());}
        }*/
    }
}