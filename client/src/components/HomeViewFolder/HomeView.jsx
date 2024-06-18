import { useEffect, useState } from "react";
import { getAllStories } from "../../managers/stories";
import { Link } from "react-router-dom";
import {
  Card,
  CardBody,
  CardSubtitle,
  CardText,
  CardTitle,
  List,
  ListGroup,
  ListGroupItem,
} from "reactstrap";
import "./HomeView.css";

export const HomeView = () => {
  const [allStories, setAllStories] = useState([]);

  useEffect(() => {
    getAllStories().then(setAllStories);
  }, []);

  return (
    <main>
      <ListGroup className="mt-5 ms-4 me-4 d-flex flex-row flex-wrap justify-content-evenly HomeView-Stories-Container">
        {allStories.map((s) => {
          return (
            <ListGroupItem key={s.id} className="mt-3">
              <Link
                to={`${s.id}`}
                style={{ textDecoration: "none", color: "#000000" }}
              >
                <Card
                  style={{
                    width: "18rem",
                  }}
                >
                  <img
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
                </Card>
              </Link>
            </ListGroupItem>
          );
        })}
      </ListGroup>
    </main>
  );
};

{
  /* <div>
<section>{s.title}</section>
<section>{s.summary}</section>
</div>
<div>
<section>{new Date(s.dateCreated).toDateString()}</section>
<section>{new Date(s.lastUpdated).toDateString()}</section>
</div> */
}
