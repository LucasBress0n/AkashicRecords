const _apiUrl = "/api/stories";

export const getAllStories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getStoryById = (StoryId) => {
  return fetch(_apiUrl + `/${StoryId}`).then((res) => res.json());
};
