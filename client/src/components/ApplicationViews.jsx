import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { HomeView } from "./HomeViewFolder/HomeView";
import { StoryDetails } from "./HomeViewFolder/StoryDetailsFolder/StoryDetails";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <p>The Akashic Terminal</p>
            </AuthorizedRoute>
          }
        />
        <Route path="story">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <HomeView />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":StoryId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <StoryDetails />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
