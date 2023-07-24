namespace _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Likes
{
     public class LikeMessages
    {
        public const string OnFailedLikedComments = "There was an issue liking this comment, please try again";
        public const string OnSuccessfulLikedComment = "You have successfully liked the comment";

        public const string OnFailedRemoveComment =
            "You have not liked the comment";

        public const string OnSuccessfulRemovedComment = "You have succesfully removed the comment";

        public const string OnFailedLikedResource = "You cannot like a resource twice";
        public const string OnSuccessfulLikedResource = "You have succesfully liked the resource";


        public const string OnFailedRemoveResource =
            "You have not liked the resource";

        public const string OnSuccesfulRemoveLikeResource = "You have sucessfully removed the like";

        public const string OnFailedUserDoNoMatch = "You cannot modify another person\'s post";
    }
}