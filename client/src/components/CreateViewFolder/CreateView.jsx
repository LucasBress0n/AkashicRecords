import { useState } from "react";
import { Button, Form } from "reactstrap";
import { postStory } from "../../managers/stories";
import { useNavigate } from "react-router-dom";

export const CreateView = ({ loggedInUser }) => {
  const [storyObject, setStoryObject] = useState({});
  const [chapterObject, setChapterObject] = useState([]);
  const [currentChapter, setCurrentChapter] = useState(0);
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (
      storyObject.Title == "" ||
      storyObject.Summary == "" ||
      storyObject.Title == undefined ||
      storyObject.Summary == undefined
    ) {
      return;
    }

    let chapterObjectsNotEmpty = true;

    chapterObject.map((c) => {
      if (
        c.ChapterTitle == "" ||
        c.StoryContent == "" ||
        c.ChapterTitle == undefined ||
        c.StoryContent == undefined
      ) {
        chapterObjectsNotEmpty = false;
      }
    });

    if (chapterObjectsNotEmpty == true && chapterObject.length != 0) {
      const storyObjectCopy = {
        ...storyObject,
        StoryChapters: [...chapterObject],
      };

      postStory({
        UserId: loggedInUser.id,
        StoryId: 0,
        IsAdmin: false,
        IsOwner: true,
        Story: { ...storyObjectCopy },
      }).then(() => {
        navigate(`/story`);
      });
    }
  };

  return (
    <main>
      <Form onSubmit={handleSubmit}>
        <Button
          onClick={() => {
            const copy = [...chapterObject];
            copy.push({
              Id:
                copy.length > 0
                  ? copy.find(
                      (item) =>
                        item.Id === Math.max(...copy.map((item) => item.Id))
                    )?.Id + 1
                  : 1,
              ChapterIndexId:
                copy.length > 0
                  ? copy.find(
                      (item) =>
                        item.ChapterIndexId ===
                        Math.max(...copy.map((item) => item.ChapterIndexId))
                    )?.ChapterIndexId + 1
                  : 1,
            });
            setChapterObject(copy);
          }}
        >
          Add Chapter
        </Button>
        <div>
          <select
            defaultValue={0}
            onChange={(e) => {
              setCurrentChapter(e.target.value);
            }}
          >
            <option value={0}>Cover</option>
            {chapterObject.length > 0 &&
              chapterObject.map((co) => {
                return (
                  <option key={co.Id} value={co.ChapterIndexId}>
                    Page: {co.ChapterIndexId}
                  </option>
                );
              })}
          </select>
          {currentChapter == 0 ? (
            <>
              <input
                onChange={(e) => {
                  const copy = { ...storyObject };
                  copy.Title = e.target.value;
                  setStoryObject(copy);
                }}
                required
                placeholder="Story Title"
                value={storyObject.Title ? storyObject.Title : ""}
              />
              <input
                onChange={(e) => {
                  const copy = { ...storyObject };
                  copy.Image = e.target.value;
                  setStoryObject(copy);
                }}
                placeholder="Image URL"
                value={storyObject.Image ? storyObject.Image : ""}
              />

              <textarea
                required
                onChange={(e) => {
                  const copy = { ...storyObject };
                  copy.Summary = e.target.value;
                  setStoryObject(copy);
                }}
                placeholder="Story Summary"
                value={storyObject.Summary ? storyObject.Summary : ""}
              />
            </>
          ) : (
            <>
              <Button
                onClick={() => {
                  const copy = chapterObject.filter(
                    (co) => co.Id != currentChapter
                  );
                  copy.map((c) => {
                    if (c.ChapterIndexId > currentChapter) {
                      c.ChapterIndexId = c.ChapterIndexId - 1;
                    }
                  });
                  setChapterObject(copy);
                  setCurrentChapter(0);
                }}
              >
                Delete
              </Button>

              {/* <select
                defaultValue={0}
                onChange={(e) => {
                  const copy = [...chapterObject];
                  copy.find((c) => c.ChapterIndexId == currentChapter)
                    .ChapterIndexId = e.target.value;
                  copy.find((c) => c.ChapterIndexId == e.target.value)
                    .ChapterIndexId == currentChapter;
                  setChapterObject(copy);
                  setCurrentChapter(0);
                }}
              >
                <option value={0}>Swap Order</option>
                {chapterObject.length > 0 &&
                  chapterObject.map((co) => {
                    if (co.ChapterIndexId != currentChapter) {
                      return (
                        <option key={co.Id} value={co.ChapterIndexId}>
                          Page: {co.ChapterIndexId}
                        </option>
                      );
                    }
                  })}
              </select> */}

              <input
                value={
                  chapterObject.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).ChapterTitle
                    ? chapterObject.find(
                        (co) => co.ChapterIndexId == currentChapter
                      ).ChapterTitle
                    : ""
                }
                required
                placeholder="Chapter Title"
                onChange={(e) => {
                  const copy = [...chapterObject];
                  copy.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).ChapterTitle = e.target.value;
                  setChapterObject(copy);
                }}
              />
              <input
                placeholder="Author Notes"
                value={
                  chapterObject.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).AuthorNotes
                    ? chapterObject.find(
                        (co) => co.ChapterIndexId == currentChapter
                      ).AuthorNotes
                    : ""
                }
                onChange={(e) => {
                  const copy = [...chapterObject];
                  copy.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).AuthorNotes = e.target.value;
                  setChapterObject(copy);
                }}
              />

              <textarea
                required
                placeholder="Story Content"
                value={
                  chapterObject.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).StoryContent
                    ? chapterObject.find(
                        (co) => co.ChapterIndexId == currentChapter
                      ).StoryContent
                    : ""
                }
                onChange={(e) => {
                  const copy = [...chapterObject];
                  copy.find(
                    (co) => co.ChapterIndexId == currentChapter
                  ).StoryContent = e.target.value;
                  setChapterObject(copy);
                }}
              />
            </>
          )}
          <Button type="submit">Save</Button>
        </div>
      </Form>
    </main>
  );
};
