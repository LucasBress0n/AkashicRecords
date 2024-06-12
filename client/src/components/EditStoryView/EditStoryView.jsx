import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getStoryById, updateStory } from "../../managers/stories";
import { getStoryAuthorByObject } from "../../managers/storiesAuthor";
import { Button, Form } from "reactstrap";
import { CoverPage, PageEditGen } from "./EditStoryViewComponents";
import { DeleteChapterById } from "../../managers/storyChapter";

export const EditStoryView = ({ loggedInUser }) => {
  const [storyData, setStoryData] = useState({});
  const [currentChapter, setCurrentChapter] = useState(0);
  const { StoryId } = useParams();
  const [permissions, setPermissions] = useState({});
  const [trashbin, setTrashbin] = useState([]);
  const navigate = useNavigate();

  const IsActuallyAuthor = () => {
    useEffect(() => {
      if (permissions.status == 404) {
        navigate(`/MyStories`);
      }
    }, [permissions]);
  };

  useEffect(() => {
    getStoryById(StoryId).then(setStoryData);
  }, []);

  useEffect(() => {
    if (
      (StoryId != null || StoryId != undefined) &&
      (loggedInUser != null || loggedInUser != undefined)
    ) {
      getStoryAuthorByObject({
        UserId: loggedInUser.id,
        StoryId: StoryId,
      }).then(setPermissions);
    }
  }, []);

  IsActuallyAuthor();

  const handleSave = (e) => {
    e.preventDefault();

    if (
      storyData.title == "" ||
      storyData.summary == "" ||
      storyData.title == undefined ||
      storyData.summary == undefined
    ) {
      return;
    }

    let chapterObjectsNotEmpty = true;

    storyData.storyChapters.map((c) => {
      if (
        c.chapterTitle == "" ||
        c.storyContent == "" ||
        c.chapterTitle == undefined ||
        c.storyContent == undefined
      ) {
        chapterObjectsNotEmpty = false;
      }
    });

    if (chapterObjectsNotEmpty == true && storyData.storyChapters.length != 0) {
      if (trashbin.length != 0) {
        trashbin.map((t) => {
          DeleteChapterById(t.id);
        });
      }

      updateStory(storyData).then(() => {
        navigate(`/MyStories`);
      });
    }
  };

  return (
    <main>
      <Form onSubmit={handleSave}>
        <Button
          onClick={() => {
            const copyStory = { ...storyData };
            copyStory.storyChapters.push({
              id:
                copyStory.storyChapters.length > 0
                  ? copyStory.storyChapters.find(
                      (item) =>
                        item.id ===
                        Math.max(
                          ...copyStory.storyChapters.map((item) => item.id)
                        )
                    )?.id + 1
                  : 1,
              chapterIndexId:
                copyStory.storyChapters.length > 0
                  ? copyStory.storyChapters.find(
                      (item) =>
                        item.chapterIndexId ===
                        Math.max(
                          ...copyStory.storyChapters.map(
                            (item) => item.chapterIndexId
                          )
                        )
                    )?.chapterIndexId + 1
                  : 1,
              IsNew: true,
            });
            setStoryData(copyStory);
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
            {storyData.storyChapters?.map((sc) => {
              return (
                <option key={sc.id} value={sc.chapterIndexId}>
                  {sc?.chapterTitle}: {sc.chapterIndexId}
                </option>
              );
            })}
          </select>
          {currentChapter == 0 ? (
            <CoverPage storyData={storyData} setStoryData={setStoryData} />
          ) : (
            <PageEditGen
              storyData={storyData}
              setStoryData={setStoryData}
              setCurrentChapter={setCurrentChapter}
              currentChapter={currentChapter}
              trashbin={trashbin}
              setTrashbin={setTrashbin}
            />
          )}
          <Button type="submit">Save</Button>
        </div>
      </Form>
    </main>
  );
};
