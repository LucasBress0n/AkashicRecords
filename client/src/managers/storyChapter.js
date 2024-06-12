const _apiUrl = "/api/storychapter";

export const DeleteChapterById = (ChapterId) => {
  return fetch(_apiUrl + `/${ChapterId}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
};
