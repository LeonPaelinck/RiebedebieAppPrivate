import { Kind } from './kind.model';

const JsonKinderen = [
  {
    lastName: 'Van Campe',
    firstName: 'Chiara',
    birthDate: '1999-06-14'
  },
  {
    lastName: 'Goethals',
    firstName: 'Zjef',
    birthDate: '2008-05-06'
  },
  {
    lastName: 'Robbrecht',
    firstName: 'Victor',
    birthDate: '2010-10-04'
  },
  {
    lastName: 'Van Lierde',
    firstName: 'JP',
    birthDate: '2018-08-08'
  },
  {
    lastName: 'De Kimpe',
    firstName: 'Amélie',
    birthDate: '2019-06-14'
  }
];
export const KINDEREN: Kind[] = JsonKinderen.map(Kind.fromJSON);