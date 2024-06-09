import { useEffect, useState } from "react";
import { getAllStories } from "../../managers/stories";

export const HomeView = () => {
  const [allStories, setAllStories] = useState([]);

  useEffect(() => {
    getAllStories().then(setAllStories);
  }, []);

  return (
    <main>
      <div>
        {allStories.map((s) => {
          return (
            <article key={s.id}>
              <div>
                <section>{s.title}</section>
                <section>{s.summary}</section>
              </div>
              <div>
                <section>{new Date(s.dateCreated).toDateString()}</section>
                <section>{new Date(s.lastUpdated).toDateString()}</section>
              </div>
            </article>
          );
        })}
      </div>
    </main>
  );
};
