import { Button } from "reactstrap";
import BlazBlue from "../Sounds/BlazBlue.mp3";

export const ExperimentalView = () => {
  return (
    <main>
      Hello
      <Button
        onClick={() => {
          const audio = new Audio();
          audio.src = BlazBlue;
          audio.loop = true;
          audio.play();
        }}
      >
        Play
      </Button>
    </main>
  );
};
