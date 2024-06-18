import { useEffect, useState } from "react";
import {
  createNewInvite,
  getAllAuthorsForAStoryByStoryId,
  getAllInvitesForAStoryByStoryId,
} from "../../managers/storiesAuthor";
import { useParams } from "react-router-dom";
import {
  Button,
  Input,
  ListGroup,
  ListGroupItem,
  ListGroupItemText,
} from "reactstrap";
import "./ManagePermissionsView.css";

export const ManagePermissionsView = ({ loggedInUser }) => {
  const [allStoryAuthors, setAllStoryAuthors] = useState([]);
  const [allInvitedAuthors, setAllInvitedAuthors] = useState([]);
  const [Usersname, setUsersname] = useState("");
  const { StoryId } = useParams();

  useEffect(() => {
    getAllAuthorsForAStoryByStoryId(StoryId).then(setAllStoryAuthors);
    getAllInvitesForAStoryByStoryId(StoryId).then(setAllInvitedAuthors);
  }, []);

  const handleInvite = () => {
    const InviteObject = {
      StoryId: StoryId,
      IsOwner: false,
      IsInvite: true,
      IsAdmin: false,
    };

    createNewInvite(InviteObject, Usersname).then(() => {
      getAllInvitesForAStoryByStoryId(StoryId).then(setAllInvitedAuthors);
    });
  };

  return (
    <main className="ManagePermissionsView-Main">
      <div className="d-flex mx-auto mt-5 text-center ManagePermissions-Div-Container">
        <ListGroup className="text-center mx-auto ManagePermissions-ListGroup-DuoContainer">
          {allStoryAuthors.map((sa) => {
            return (
              <ListGroupItem key={sa.id}>
                <ListGroupItemText>{sa.userProfile.userName}</ListGroupItemText>
              </ListGroupItem>
            );
          })}
        </ListGroup>
        <ListGroup className="text-center mx-auto ManagePermissions-ListGroup-DuoContainer">
          <div className="d-flex">
            <Input
              value={Usersname}
              type="search"
              onChange={(e) => {
                setUsersname(e.target.value);
              }}
            />
            <Button
              onClick={() => {
                handleInvite();
              }}
            >
              Invite
            </Button>
          </div>
          {allInvitedAuthors.map((ia) => {
            return (
              <ListGroupItem key={ia.id}>
                <ListGroupItemText>{ia.userProfile.userName}</ListGroupItemText>
              </ListGroupItem>
            );
          })}
        </ListGroup>
      </div>
    </main>
  );
};
