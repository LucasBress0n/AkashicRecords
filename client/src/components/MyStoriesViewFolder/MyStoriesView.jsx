import { useEffect, useState } from "react";
import { getStoriesIncludingUser } from "../../managers/atoriesAuthor";
import { Link, useNavigate } from "react-router-dom";
import { Button } from "reactstrap";

export const MyStories = ({ loggedInUser }) => {
  const [storiesUserIsApartOf, setStoriesUserIsApartOf] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getStoriesIncludingUser(loggedInUser.id).then(setStoriesUserIsApartOf);
  }, []);

  return (
    <main>
      <div>
        {storiesUserIsApartOf.map((sa) => {
          const s = sa.story;
          return (
            <article key={s.id}>
              <Link
                to={`/story/${s.id}`}
                style={{ textDecoration: "none", color: "#000000" }}
              >
                <div>
                  <section>{s.title}</section>
                  <section>{s.summary}</section>
                </div>
                <div>
                  <section>{new Date(s.dateCreated).toDateString()}</section>
                  <section>{new Date(s.lastUpdated).toDateString()}</section>
                </div>
              </Link>
              <Button
                onClick={() => {
                  navigate(`/story/${s.id}/edit`);
                }}
              >
                Edit
              </Button>
              <Button>Settings</Button>
            </article>
          );
        })}
      </div>
    </main>
  );
};
