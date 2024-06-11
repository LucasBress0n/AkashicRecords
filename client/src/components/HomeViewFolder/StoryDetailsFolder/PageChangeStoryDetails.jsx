import { Button } from "reactstrap";

export const StoryCover = ({
  story,
  setCurrentIndex,
  storyChapters,
  currentIndex,
}) => {
  return (
    <div>
      <h4>{story.title}</h4>
      <section>
        <img />
        <div>
          <p>{story.summary}</p>
        </div>
        <div>
          <p>{new Date(story.dateCreated).toDateString()}</p>
          <p>{new Date(story.lastUpdated).toDateString()}</p>
        </div>
      </section>
      <div>
        <Button>&lt;</Button>
        <Button
          onClick={() => {
            if (
              storyChapters.find(
                (sc) => sc.chapterIndexId == currentIndex + 1
              ) != undefined
            ) {
              setCurrentIndex(currentIndex + 1);
            }
          }}
        >
          &gt;
        </Button>
      </div>
    </div>
  );
};

export const PageGenerator = ({
  currentPage,
  setCurrentIndex,
  storyChapters,
  currentIndex,
}) => {
  if (currentPage === undefined) {
    return;
  }

  return (
    <div>
      <h4>{currentPage.chapterTitle}</h4>
      <section>
        <p>{currentPage.authorNotes}</p>
        <div>
          <p>{currentPage.storyContent}</p>
        </div>
        <p>{new Date(currentPage.dateCreated).toDateString()}</p>
      </section>
      <div>
        <Button
          onClick={() => {
            setCurrentIndex(currentIndex - 1);
          }}
        >
          &lt;
        </Button>
        <Button
          onClick={() => {
            if (
              storyChapters.find(
                (sc) => sc.chapterIndexId == currentIndex + 1
              ) != undefined
            ) {
              setCurrentIndex(currentIndex + 1);
            }
          }}
        >
          &gt;
        </Button>
      </div>
    </div>
  );
};
