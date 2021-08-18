import { createReducer, on } from '@ngrx/store';
import { reset } from './counter.actions'; //Verschillende acties
 
export const initialState = [];
 
const _counterReducer = createReducer( //switch die bekijkt welke actie is uitgevoerd
  initialState,
  on(reset, (state) => [])
);
 
export function counterReducer(state, action) { //State is wat er behandeld wordt
  return _counterReducer(state, action);
}