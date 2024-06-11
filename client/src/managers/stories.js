const _apiUrl = "/api/stories";

export const getAllStories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getStoryById = (StoryId) => {
  return fetch(_apiUrl + `/${StoryId}`).then((res) => res.json());
};

export const postStory = (StoryAuthorObjectWithStory) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(StoryAuthorObjectWithStory),
  });
};
