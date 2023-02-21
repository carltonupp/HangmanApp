import { Home } from "./components/Home";
import {Game} from "./components/Game";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/game/:gameId',
    element: <Game />
  }
];

export default AppRoutes;
