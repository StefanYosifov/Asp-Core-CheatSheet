import { get } from "./requests";

export const GetStatistics=()=>{
  return get(`statistics/all`);
}
  