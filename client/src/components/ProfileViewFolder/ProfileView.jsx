import { useEffect } from "react";
import { useState } from "react";
import { getUserWithStoriesById } from "../../managers/user";
import { useParams } from "react-router-dom";
import {
  acceptInvite,
  declineInvite,
  getAllInvitesBelongingToAUserByUserId,
} from "../../managers/storiesAuthor";
import {
  Button,
  ListGroup,
  ListGroupItem,
  ListGroupItemText,
} from "reactstrap";

export const ProfileView = ({ loggedInUser }) => {
  const [userProfileData, setUserProfileData] = useState({});
  const [usersInvites, setUsersInvites] = useState([]);
  const [isUserOwner, setIsUserOwner] = useState(false);
  const { UserId } = useParams();

  useEffect(() => {
    getUserWithStoriesById(UserId).then(setUserProfileData);
  }, []);

  useEffect(() => {
    if (parseInt(UserId) == loggedInUser.id) {
      setIsUserOwner(true);
      getAllInvitesBelongingToAUserByUserId(UserId).then(setUsersInvites);
    }
  }, []);

  const HandleAccept = (InviteObject) => {
    acceptInvite(InviteObject).then(() => {
      getAllInvitesBelongingToAUserByUserId(UserId).then(setUsersInvites);
    });
  };

  const HandleDelete = (InviteObject) => {
    declineInvite(InviteObject).then(() => {
      getAllInvitesBelongingToAUserByUserId(UserId).then(setUsersInvites);
    });
  };

  return (
    <main>
      <div>
        <h4>{userProfileData.fullName}</h4>
        <p>{userProfileData.email}</p>
        <p>{userProfileData.userName}</p>
      </div>

      {isUserOwner == true && (
        <ListGroup>
          <h5>Invites</h5>
          {usersInvites.map((ui) => {
            return (
              <ListGroupItem key={ui.id}>
                <ListGroupItemText>{ui.story.title}</ListGroupItemText>
                <Button
                  onClick={() => {
                    HandleAccept(ui);
                  }}
                >
                  Accept
                </Button>
                <Button
                  onClick={() => {
                    HandleDelete(ui);
                  }}
                >
                  Decline
                </Button>
              </ListGroupItem>
            );
          })}
        </ListGroup>
      )}
    </main>
  );
};
