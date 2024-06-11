import { useEffect, useState } from "react";
import { getStoryById } from "../../../managers/stories";
import { useParams } from "react-router-dom";
import { PageGenerator, StoryCover } from "./PageChangeStoryDetails";

export const StoryDetails = () => {
  const [storyWithChapters, setStoryWithChapters] = useState({});
  const [storyChapters, setStoryChapters] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [currentPage, setCurrentPage] = useState({});
  const { StoryId } = useParams();

  useEffect(() => {
    getStoryById(StoryId).then(setStoryWithChapters);
  }, []);

  useEffect(() => {
    setStoryChapters(storyWithChapters.storyChapters);
  }, [storyWithChapters]);

  useEffect(() => {
    setCurrentPage(
      storyChapters.find((sc) => sc.chapterIndexId == currentIndex)
    );
  }, [currentIndex]);

  return (
    <main>
      <div>
        {currentIndex == 0 ? (
          <StoryCover
            story={storyWithChapters}
            setCurrentIndex={setCurrentIndex}
            storyChapters={storyChapters}
            currentIndex={currentIndex}
          />
        ) : (
          <PageGenerator
            currentPage={currentPage}
            setCurrentIndex={setCurrentIndex}
            storyChapters={storyChapters}
            currentIndex={currentIndex}
          />
        )}
      </div>
    </main>
  );
};
