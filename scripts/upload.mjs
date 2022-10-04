import { NFTStorage } from 'nft.storage'
import { filesFromPath } from 'files-from-path'
import path from 'path'

const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkaWQ6ZXRocjoweEI0MEUzQTkwYWNDRDRjQ0Y2QTIyZjYwQ2YzZTY4OGQxM0FkQjgyNkEiLCJpc3MiOiJuZnQtc3RvcmFnZSIsImlhdCI6MTY2NDU0MjE5Nzg4NywibmFtZSI6Ik1ldGFkYXRhIHBhc3RlIn0.mzAJIGNTkBeohS7qxhzOPInOq3ul1lnUu5MXt6CfBcg';

async function main() {
  // you'll probably want more sophisticated argument parsing in a real app
  if (process.argv.length !== 3) {
    console.error(`usage: ${process.argv[0]} ${process.argv[1]} <directory-path>`)
  }
  const directoryPath = process.argv[2]
  const files = filesFromPath(directoryPath, {
    pathPrefix: path.resolve(directoryPath), // see the note about pathPrefix below
    hidden: true, // use the default of false if you want to ignore files that start with '.'
  })

  const storage = new NFTStorage({ token })

  console.log(`storing file(s) from ${path}`)
  const cid = await storage.storeDirectory(files)
  console.log({ cid })

  const status = await storage.status(cid)
  console.log(status)
}
main();