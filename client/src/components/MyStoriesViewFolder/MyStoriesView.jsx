import { useEffect, useState } from "react";
import { getStoriesIncludingUser } from "../../managers/storiesAuthor";
import { Link, useNavigate } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardSubtitle,
  CardText,
  CardTitle,
  ListGroup,
  ListGroupItem,
} from "reactstrap";
import "./MyStoriesView.css";

export const MyStories = ({ loggedInUser }) => {
  const [storiesUserIsApartOf, setStoriesUserIsApartOf] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getStoriesIncludingUser(loggedInUser.id).then(setStoriesUserIsApartOf);
  }, []);

  return (
    <main>
      <div>
        <ListGroup className="mt-5 ms-4 me-4 mx-auto d-flex flex-row flex-wrap justify-content-evenly HomeView-Stories-Container">
          {storiesUserIsApartOf.map((sa) => {
            const s = sa.story;
            return (
              <ListGroupItem key={s.id} className="mt-3">
                <Card
                  style={{
                    width: "18rem",
                  }}
                >
                  <Link
                    to={`/story/${s.id}`}
                    style={{ textDecoration: "none", color: "#000000" }}
                  >
                    <img
                      height={160}
                      className="MyStoriesView-Img-Card"
                      alt="Sample"
                      src={
                        s.image != null
                          ? s.image
                          : "https://media.nbcdfw.com/2022/05/530a-p-mock-drowning_KXASWR5P_2022-05-24-06-22-15-1.jpg?quality=85&strip=all&fit=1920%2C1080"
                      }
                    />
                    <CardBody>
                      <CardTitle tag="h5">{s.title}</CardTitle>
                      <CardSubtitle className="mb-2 text-muted" tag="h6">
                        {new Date(s.dateCreated).toDateString()} ---{" "}
                        {new Date(s.lastUpdated).toDateString()}
                      </CardSubtitle>
                      <CardText>{s.summary}</CardText>
                    </CardBody>
                  </Link>
                  <Button
                    onClick={() => {
                      navigate(`/story/${s.id}/edit`);
                    }}
                  >
                    Edit
                  </Button>
                  <Button
                    onClick={() => {
                      navigate(`/ManagePerms/${s.id}`);
                    }}
                  >
                    Settings
                  </Button>
                </Card>
              </ListGroupItem>
            );
          })}
        </ListGroup>
      </div>
    </main>
  );
};
