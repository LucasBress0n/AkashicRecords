import { Button } from "reactstrap";

export const CoverPage = ({ storyData, setStoryData }) => {
  return (
    <article>
      <input
        onChange={(e) => {
          const copy = { ...storyData };
          copy.title = e.target.value;
          setStoryData(copy);
        }}
        required
        placeholder="Story Title"
        value={storyData.title ? storyData.title : ""}
      />
      <input
        onChange={(e) => {
          const copy = { ...storyData };
          copy.image = e.target.value;
          setStoryData(copy);
        }}
        placeholder="Image URL"
        value={storyData.image ? storyData.image : ""}
      />

      <textarea
        required
        onChange={(e) => {
          const copy = { ...storyData };
          copy.summary = e.target.value;
          setStoryData(copy);
        }}
        placeholder="Story Summary"
        value={storyData.summary ? storyData.summary : ""}
      />
    </article>
  );
};

export const PageEditGen = ({
  storyData,
  setStoryData,
  currentChapter,
  setCurrentChapter,
  trashbin,
  setTrashbin,
}) => {
  return (
    <article>
      <Button
        onClick={() => {
          const copy = storyData;
          const trashbinCopy = [...trashbin];
          const trash = copy.storyChapters
            .filter((scObj) => !scObj.hasOwnProperty(`IsNew`))
            .find((sc) => sc.chapterIndexId == currentChapter);
          if (trash != undefined) {
            trashbinCopy.push(trash);
          }
          setTrashbin(trashbinCopy);

          copy.storyChapters = copy.storyChapters.filter(
            (co) => co.chapterIndexId != currentChapter
          );

          copy.storyChapters.map((c) => {
            if (c.chapterIndexId > currentChapter) {
              c.chapterIndexId = c.chapterIndexId - 1;
            }
          });
          setStoryData(copy);
          setCurrentChapter(0);
        }}
      >
        Delete
      </Button>

      <input
        required
        placeholder="Chapter Title"
        onChange={(e) => {
          const copyStory = { ...storyData };
          copyStory.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).chapterTitle = e.target.value;
          setStoryData(copyStory);
        }}
        value={
          storyData.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).chapterTitle
            ? storyData.storyChapters.find(
                (co) => co.chapterIndexId == currentChapter
              ).chapterTitle
            : ""
        }
      />
      <input
        placeholder="Author Notes"
        onChange={(e) => {
          const copyStory = { ...storyData };
          copyStory.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).authorNotes = e.target.value;
          setStoryData(copyStory);
        }}
        value={
          storyData.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).authorNotes
            ? storyData.storyChapters.find(
                (co) => co.chapterIndexId == currentChapter
              ).authorNotes
            : ""
        }
      />

      <textarea
        required
        placeholder="Story Content"
        onChange={(e) => {
          const copyStory = { ...storyData };
          copyStory.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).storyContent = e.target.value;
          setStoryData(copyStory);
        }}
        value={
          storyData.storyChapters.find(
            (co) => co.chapterIndexId == currentChapter
          ).storyContent
            ? storyData.storyChapters.find(
                (co) => co.chapterIndexId == currentChapter
              ).storyContent
            : ""
        }
      />
    </article>
  );
};
