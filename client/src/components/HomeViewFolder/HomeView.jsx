import { useState } from "react";

export const HomeView = () => {
  const [allStories, setAllStories] = useState([]);

  return (
    <main>
      <div>
        {allStories.map((s) => {
          return <article>s</article>;
        })}
      </div>
    </main>
  );
};
